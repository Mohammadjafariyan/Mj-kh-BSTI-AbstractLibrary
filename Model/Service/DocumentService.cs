using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Xceed.Words.NET;

namespace BigPardakht.Model.Service
{
    public class DocumentService
    {
        public string basePath { get; set; } =@"D:\mohammad\workplace\1400\khInventory-last\kh-inventory\BigPardakht\wwwroot\Print";

        
        /*public DocumentService(string basePath)
        {
            this.basePath = basePath;
        }*/
        


       

        static IEnumerable<object[]> SampleData()
        {
            var measurement = new Dictionary<string, string>();
            // Do what you want with your dictionary

            measurement.Add("@date", "سلام"); // Do what you want with your dictionary

            List<HavalePrintRow> rows = new List<HavalePrintRow>();

            int c = 0;
            rows.Add(new HavalePrintRow
            {
                Description = "نهاده دامی گندم",
                BozKg = "20",
                CowKg = "20",
                RowId = c++,
                TotalPrice = "350.000",
                UnitPrice = "15.000.000"
            });

            rows.Add(new HavalePrintRow
            {
                Description = "نهاده دامی آرد",
                BozKg = "20",
                CowKg = "20",
                RowId = c++,
                TotalPrice = "350.000",
                UnitPrice = "15.000.000"
            });


            rows.Add(new HavalePrintRow
            {
                Description = "نهاده دامی جو",
                BozKg = "20",
                CowKg = "20",
                RowId = c++,
                TotalPrice = "350.000",
                UnitPrice = "15.000.000"
            });
            // The order of element in the object my be the same expected by your test method
            return new[] {new object[] {measurement, rows},};
        }

        public static string GenerateName(int len)
        { 
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return Name;


        }
        public string GenerateRandomNameNotExist()
        {
            var txt = Guid.NewGuid();
            Console.WriteLine(txt);
            
            var newPath= Path.Combine(basePath,
                @$"{txt}.docx");


            if (File.Exists(newPath))
                return GenerateRandomNameNotExist();
            
            
            return newPath ;
        }

        public void OpenAndReplaceDocTest(Dictionary<string, string> replaceWords,
            List<HavalePrintRow> rows)
        {
            OpenAndReplaceDoc(replaceWords, rows);
        }
        
        
        public string OpenAndReplaceDoc(Dictionary<string, string> replaceWords,
            List<HavalePrintRow> rows)
        {
            string fileName =
                Path.Combine(basePath,
                    "PrintTemp.docx");

            string newFile =GenerateRandomNameNotExist();
            

            ReadToStream(fileName, newFile,
                (fileStream =>
                {
                    using (var document = DocX.Load(fileStream))
                    {
                        foreach (var replaceWord in replaceWords)
                        {
                            document.ReplaceText(replaceWord.Key, replaceWord.Value);
                        }

                        // Get the table to modify
                        var table = document.Tables[1];


                        for (int i = 0; i < rows.Count; i++)
                        {

                            table.InsertRow();

                            int j = i + 1;
                            int c = 0;
                            table.Rows[j].Cells[c++].Paragraphs[0].Append(rows[i].RowId.ToString());
                            table.Rows[j].Cells[c++].Paragraphs[0].Append(rows[i].Description.ToString());
                            table.Rows[j].Cells[c++].Paragraphs[0].Append(rows[i].CowKg.ToString());
                            table.Rows[j].Cells[c++].Paragraphs[0].Append(rows[i].BozKg.ToString());
                            table.Rows[j].Cells[c++].Paragraphs[0].Append(rows[i].UnitPrice.ToString());
                            table.Rows[j].Cells[c++].Paragraphs[0].Append(rows[i].TotalPrice.ToString());
                        }

                        document.SaveAs(newFile);
                    }
                }));


            SetTimeout(() =>
            {
                File.Delete(newFile);
            }, 1000*60);


            return newFile;
        }

        public CancellationTokenSource SetTimeout(Action action, int millis) {

            var cts = new CancellationTokenSource();
            var ct = cts.Token;
            _ = Task.Run(() => {
                Thread.Sleep(millis);
                if (!ct.IsCancellationRequested)
                    action();
            }, ct);

            return cts;
        }
        
        protected FileStream ReadToStream(string path, string newPath,
            Action<FileStream> func)
        {
            using (FileStream fsSource = new FileStream(path,
                FileMode.Open, FileAccess.Read))
            {
                // Read the source file into a byte array.
                byte[] bytes = new byte[fsSource.Length];
                int numBytesToRead = (int) fsSource.Length;
                int numBytesRead = 0;
                while (numBytesToRead > 0)
                {
                    // Read may return anything from 0 to numBytesToRead.
                    int n = fsSource.Read(bytes, numBytesRead, numBytesToRead);

                    // Break when the end of the file is reached.
                    if (n == 0)
                        break;

                    numBytesRead += n;
                    numBytesToRead -= n;
                }

                numBytesToRead = bytes.Length;

                /*// Write the byte array to the other FileStream.
                using (FileStream fsNew = new FileStream(newPath,
                    FileMode.Create, FileAccess.ReadWrite))
                {
                    fsNew.Write(bytes, 0, numBytesToRead);


                }*/
                func(fsSource);

                return fsSource;
            }
        }
    }

    public class HavalePrintRow
    {
        public int RowId { get; set; }
        public string Description { get; set; }
        public string BozKg { get; set; }
        public string CowKg { get; set; }
        public string UnitPrice { get; set; }
        public string TotalPrice { get; set; }
    }
}