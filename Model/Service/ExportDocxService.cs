using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Reflection;
using AbstractLibrary.FormBuilder;
using AbstractLibrary.Model;
using Xceed.Words.NET;

namespace BigPardakht.Model.Service
{
    public class ExportDocxService : DocumentService, IExportDocxService
    {
        public string ExportDocx<T>(Dictionary<string, string> replaceWords,
            TableVCModel Model, string templateName, T sampleEntity)
        {
            var propertyInfos = sampleEntity.GetType().GetProperties();

            string fileName =
                Path.Combine(basePath,
                    templateName);

            string newFile = GenerateRandomNameNotExist();


            ReadToStream(fileName, newFile,
                (fileStream =>
                {
                    using (var document = DocX.Load(fileStream))
                    {
                        foreach (var replaceWord in replaceWords)
                        {
                            document.ReplaceText(replaceWord.Key, replaceWord.Value);
                        }


                        #region افزودن ستون ها

                        var table = document.Tables[0];
                        int columnIndex = 0;

                        if (Model.FirstColumns != null)
                        {
                            foreach (var column in Model.FirstColumns)
                            {
                                table.InsertColumn();
                                var txt = column.Key;
                                table.Rows[0].Cells[columnIndex++].Paragraphs[0].Append(txt);
                            }
                        }

                        foreach (PropertyInfo prop in propertyInfos)
                        {
                            string translate = MyGlobal.GetTranslate()[prop.Name];


                            if (prop.IsHasAttribute<HiddenAttribute>() ||
                                prop.IsHasAttribute<RichTextAttribute>() ||
                                prop.IsHasAttribute<DontPrintAttribute>())
                            {
                            }
                            else
                            {
                                table.InsertColumn();
                                if (prop.IsHasAttribute<DisplayAttribute>())
                                {
                                    var foo = prop.GetCustomAttribute<DisplayAttribute>();
                                    table.Rows[0].Cells[columnIndex++].Paragraphs[0].Append(foo.Name);
                                }
                                else
                                {
                                    table.Rows[0].Cells[columnIndex++].Paragraphs[0].Append(translate);
                                }
                            }
                        }

                        #endregion


                        #region خود گزارش

                        for (int i = 0; i < Model.table.EntityList.Count; i++)
                        {
                            int rowIndex = i + 1;
                            columnIndex = 0;
                            table.InsertRow();

                            var entity = Model.table.EntityList[i];

                            if (Model.FirstColumns != null)
                            {
                                foreach (var column in Model.FirstColumns)
                                {
                                    var txt = column.Value(entity);
                                    table.Rows[rowIndex].Cells[columnIndex++].Paragraphs[0].Append(txt);
                                }
                            }

                            foreach (PropertyInfo prop in propertyInfos)
                            {
                                var val = prop.GetValue(entity);

                                if (Model.Pipe != null && Model.Pipe.ContainsKey(prop.Name))
                                {
                                    var txt = Model.Pipe[prop.Name](entity);
                                    table.Rows[rowIndex].Cells[columnIndex++].Paragraphs[0].Append(txt);

                                    continue;
                                }

                                if (prop.IsHasAttribute<HiddenAttribute>() ||
                                    prop.IsHasAttribute<RichTextAttribute>() ||
                                    prop.IsHasAttribute<DontPrintAttribute>())
                                {
                                }
                                else
                                {
                                    if ((val as IEntity) != null)
                                    {
                                        var _entity = val as IEntity;
                                        table.Rows[rowIndex].Cells[columnIndex++].Paragraphs[0].Append(_entity.Name);
                                    }
                                    else if (val is decimal)
                                    {
                                        var _val = (val as decimal?).Value.ToTrimmedString();
                                        table.Rows[rowIndex].Cells[columnIndex++].Paragraphs[0].Append(_val);
                                    }
                                    else
                                    {
                                        table.Rows[rowIndex].Cells[columnIndex++].Paragraphs[0].Append(val?.ToString() ?? "");
                                    }
                                }
                            }
                        }


                        #endregion


                        document.SaveAs(newFile);
                    }
                }));


            SetTimeout(() => { File.Delete(newFile); }, 1000 * 60);


            return newFile;
        }
    }
}