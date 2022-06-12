using System.Collections.Generic;
using AbstractLibrary.Model.User;
using BigPardakht.Data;
using BigPardakht.Model;
using BigPardakht.Model.Gateway;
using BigPardakht.Model.User;
using BigPardakht.Repository.Initial;
using Microsoft.EntityFrameworkCore;
using SignalRMVCChat.Service;
using TelegramBotsWebApplication.Service;
using ApplicationUser = AbstractLibrary.Model.User.ApplicationUser;

namespace BigPardakht.IC
{
    public class DebugDbSeed
    {
        
        public  static string CurrentApiToken=EncryptionHelper.GenerateTokenBySize(20);
        private static List<PaymentGateway> _PaymentGateways = new List<PaymentGateway>
        {
            new PaymentGateway
            {
                Id = 1,
                CustomerId = 1,
                AcceptanceStatus = AcceptanceStatus.Accepted,
                WebsiteUrl = "https://localhost:5001/",
                GatewayUniqueAddress = "tina_Shop",
                Name = "tina_Shop",
                ExchangeType = ExchangeType.PaymentTime,
                UNIQUE_API_TOKEN=CurrentApiToken
            }
        };
        
        private static List<Wallet> _GatewayWallets = new List<Wallet>
        {
            new Wallet
            {
                Id = 1,
                PaymentGatewayId = 1,
                CurrencyId = 1
                /*WalletId = 1*/
            }
        };
        private static List<Wallet> _wallets = new List<Wallet>
        {
            new Wallet
            {
                Id = 1,
                CustomerId = 1,
                Name = "wallet 1",
                PaymentGatewayId = 1
            },
            new Wallet
            {
                Id = 2,
                CustomerId = 1,
                Name = "wallet 2",
                PaymentGatewayId = 1

            },
        };

        private static List<Customer> customerList = new List<Customer>
        {
            new Customer
            {
                Id = 1,
                ApplicationUserId = 1,
                Name = "سعید",
                Phone = "09148980692",
                AcceptanceStatus = AcceptanceStatus.Accepted,
                CustomerType = CustomerType.Haghighi,
                BusinessAddress = "",
                BusinessDomain = "",
                BusinessPhone = "",
                BusinessCeoName = "",
                BusinessMiliCode = "",
                BusinessUniqId = "",
                BusinessSubmitDate = "",
                BusinessPostalCode = "",
                BusinessSabtCode = "",
            }
        };

        public static void Seed(ModelBuilder builder)
        {
            /*builder.Entity<ApplicationUser>()
                .HasData(data: new List<ApplicationUser>
                {
                    new ApplicationUser
                    {
                        Id = 1,
                        Email = "admin@admin.com",
                        Name = "admin@admin.com",
                        //Admin1@admin.com
                        PasswordHash =
                            "AQAAAAEAACcQAAAAENkO7WtT1k5ofHJG3z1UWeqjc/aVUzeYLR0GAabeENpUEq47x82jMnYmjnja6FjZ8A==",
                    }
                });*/


            builder.Entity<Customer>()
                .HasData(customerList);


            builder.Entity<Wallet>()
                .HasData(data: _wallets);
            
            
            
            builder.Entity<PaymentGateway>()
                .HasData(data: _PaymentGateways);
            
            
            /*
            builder.Entity<Wallet>()
                .HasData(data: _GatewayWallets);*/
            
            
            builder.Entity<Setting>()
                .HasData(data: new Setting()
                {
                    Id = 1
                });
        }

        public static void SeedDataOnly(ApplicationDbContext context)
        {
            /*context.Customers.AddRange(customerList);
            context.Wallet.AddRange(_wallets);


            context.Currencies.AddRange(CurrencyRepository.Seed());

            context.SaveChanges();*/
        }
    }
}