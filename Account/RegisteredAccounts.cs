using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class RegisteredAccounts
{
    static readonly string ExcelFilePath = @"/Users/apple/Documents/Programming Coding/C#/ATM/ATM/Database/RegisteredAccounts.xlsx";

    public static List<Account> GetAccounts()
    {
        List<Account> accounts = new List<Account>();

        FileInfo fileInfo = new FileInfo(ExcelFilePath);
        if (!fileInfo.Exists)
        {
            Console.WriteLine("Excel file does not exist.");
            return accounts;
        }

        try
        {
            using ExcelPackage package = new ExcelPackage(fileInfo);
            ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
            if (worksheet != null && worksheet.Dimension != null)
            {
                int rowCount = worksheet.Dimension.Rows;

                // Console.WriteLine(rowCount);
                for (int row = 2; row <= rowCount; row++)
                {
                    Account account = new Account
                    {
                        Name = worksheet.Cells[row, 1].Value?.ToString(),
                        AccountNumber = Convert.ToInt64(worksheet.Cells[row, 2].Value),
                        Pin = Convert.ToInt32(worksheet.Cells[row, 3].Value),
                        Balance = Convert.ToDouble(worksheet.Cells[row, 4].Value),
                
                    };
                    accounts.Add(account);
                }
            }
            else
            {
                Console.WriteLine("Worksheet 'Accounts' not found in Excel file.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading Excel file: {ex.Message}");
        }

        return accounts;
    }

    public static void AddAccount(Account account)
    {
        string directoryPath = Path.GetDirectoryName(ExcelFilePath);
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        FileInfo fileInfo = new FileInfo(ExcelFilePath);
        
        try
        {
            using ExcelPackage package = new ExcelPackage(fileInfo);
            ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
            if (worksheet == null)
            {
                worksheet = package.Workbook.Worksheets.Add("Accounts");
            }

                
                int rowCount = worksheet.Dimension?.Rows ?? 0;
                worksheet.Cells[rowCount + 1, 1].Value = account.Name;
                worksheet.Cells[rowCount + 1, 2].Value = account.AccountNumber;
                worksheet.Cells[rowCount + 1, 3].Value = account.Pin;
                worksheet.Cells[rowCount + 1, 4].Value = account.Balance;
                worksheet.Cells[rowCount + 1, 5].Value = account.OpeningDate;

             package.Save();
            Console.WriteLine("Account added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving account: {ex.Message}");
        }
    }

    public static void UpdateAccount(IAccount updatedAccount)
    {

        FileInfo fileInfo = new FileInfo(ExcelFilePath);
        try
        {
            using ExcelPackage package = new ExcelPackage(fileInfo);
            ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
            if (worksheet == null)
            {
                Console.WriteLine("Accounts worksheet not found.");
                return;
            }

            int rowCount = worksheet.Dimension?.Rows ?? 0;

            // Find the row containing the account to update based on AccountNumber
            int rowIndex = 0;
            for (int i = 1; i <= rowCount; i++)
            {
                if (worksheet.Cells[i, 2].Value?.ToString() == updatedAccount.AccountNumber.ToString())
                {
                    rowIndex = i;
                    break;
                }
            }

            if (rowIndex == 0)
            {
                Console.WriteLine("Account not found in the worksheet.");
                return;
            }

            worksheet.Cells[rowIndex, 1].Value = updatedAccount.Name;
            worksheet.Cells[rowIndex, 3].Value = updatedAccount.Pin;
            worksheet.Cells[rowIndex, 4].Value = updatedAccount.Balance;
            worksheet.Cells[rowCount + 1, 5].Value = updatedAccount.OpeningDate;

        package.Save();
            Console.WriteLine("Account updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating account: {ex.Message}");
        }
    }

}
