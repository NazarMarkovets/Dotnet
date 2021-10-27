using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Dotnet.Lib;
using Lib.AbstractClassUsage;
using Lib.Async;
using Lib.DelegatesAndLambda;
using Lib.Models.Companies;
using Lib.Models.Persons;
using Lib.Modules;
using Lib.Patterns.Builder;
using ParallelProgramming;
using TraceManager;
using static System.String;


namespace Main
{
    internal static class Program
    {
        public static void Main()
        {
            // UsingPersonInterface();
            // UsingBankModule();
            // UsingDictionary();
            // UsingAbstractClass();
            //UsingBuilderPattern();
            //UsingDelegates();

            // LinqManager.LinqSelect();
            // LinqManager.LinqSelectByParameter();
            // LinqManager.LinqTakeWhile();
            // LinqManager.LinqSelectSortedByAgeDesc();
            // LinqManager.LinqSelectLastOrDefault();
            // CreatingHashMap();
            // FilteringUsageVB();
           
            //AsyncProgramming.ThreadLoopWithInfo();

            //new ThreadSync().SyncCreatingReadingMessages();
            //new ThreadSync().SyncTraficLightsWork(); 
            new ThreadSync().SyncParkingLot();
        }
        

        /// <summary>
        /// <remarks>
        /// Create person module class to do implementation of IPerson.
        /// Initialize param must get new object, otherwise it returns exception
        /// </remarks>
        /// </summary>
        private static void UsingPersonInterface()
        {
            var person = new PersonModule();
            person.InitializePerson(new ManagerModel("Daniel", 55));
            person.GetAllData();
            person.InitializePerson(new WorkerModel("Gloria", 22));
            person.GetAllData();
        }

        private static void UsingBankModule()
        {
            var bankModule = new BankModule(
                new Bank("Global Bank", 2000),
                new PrivatBank("Privat24", 5, 50));
            bankModule.Bank.GetBankData();
            bankModule.PrivatBank.GetBankData();
            bankModule.GetAllUsersFromBank(bankModule.Bank.ReturnAllUsers());
            bankModule.GetAllUsersFromBank(bankModule.PrivatBank.ReturnAllUsers());
        }

        private static void UsingDictionary()
        {
            var dictionaryModule = new DictionaryModule();
            dictionaryModule.AddDataToDictionary(dictionaryModule.someDictionary);
            dictionaryModule.GetAllDictionaryKeys(dictionaryModule.someDictionary);
            dictionaryModule.GetDataFromDictionary(dictionaryModule.someDictionary);
            dictionaryModule.TrimDictionary(dictionaryModule.someDictionary, 4);
            dictionaryModule.TryGetDictionaryValue(dictionaryModule.someDictionary, "key 2");
            dictionaryModule.SearchValueByKey(dictionaryModule.someDictionary, "key 1");
            var returnedDictionaryKeys = dictionaryModule.ReturnKeys(dictionaryModule.someDictionary).ToList();
            returnedDictionaryKeys.ForEach(key => Console.Write($"Returned Keys: {key} \n"));
            Console.WriteLine();
        }

        /// <summary>
        /// <remarks>
        /// Showing Upcast Features for Abstract class Person
        /// </remarks>
        /// </summary>
        private static void UsingAbstractClass()
        {
            Person person = new Employer("C1", 300.50m);
            person.Age = 50;
            person.ShowAge();
            person.ShowCategory();
            person.ShowAgeNotAbstract();
            person.ShowPersonSalary();
            Console.WriteLine($"Employee percents is {person.GetPersentsOfSalary()}");

            //---- Worker

            person = new UsualWorker(50.50m);
            person.ShowAge();
            person.ShowAgeNotAbstract();
            person.ShowPersonSalary(50.50d);
            person.ShowPersonSalary();
            person.ShowCategory();
            Console.WriteLine($"Usual Worker persents is {person.GetPersentsOfSalary()}");

            // -- Not using UpCast
            Employer employer = new Employer("C2", 900m);
            employer.ShowAge();
            employer.ShowCatagory();

            employer.ShowPersonSalary();
            employer.ShowCatagory();
        }

        private static void UsingBuilderPattern()
        {
            Director director = new Director("Part 1 ", "Part 2 ");

            ConcreteBuilderA concreteBuilderA = new ConcreteBuilderA();
            director.Construct(concreteBuilderA);
            Product product1 = concreteBuilderA.ReturnAllProducts();
            product1.ShowAllProducts();

            ConcreteBuilderB concreteBuilderB = new ConcreteBuilderB();
            director.ChangeParts("Part3 ", "Part 4");
            director.Construct(concreteBuilderB);

            Product product2 = concreteBuilderB.ReturnAllProducts();
            product2.ShowAllProducts();
        }

        /// <summary>
        /// Shows working of delegates
        /// Show 10 random calls of 4 types of methods
        /// Use Tracing in TraceManager
        /// </summary>
        private static void UsingDelegates()
        {
            var counter = 0;
            var random = new Random();
            var tracing = new Tracing();
            while (counter < 10)
            {
                var value = random.Next(1, 10);
                object Result = null;
                switch (value % 2)
                {
                    case 0 when value < 5:
                    {
                            DelegatesExample.CreateUserWithPredefinedData userWithPredefinedData =
                            DelegatesExample.CreateWorkerModel_Stat;
                        tracing.AddToTracing(counter, userWithPredefinedData);
                        Result = userWithPredefinedData.Invoke();
                        tracing.ShowInfo(userWithPredefinedData);
                        tracing.GetObjectType(userWithPredefinedData);
                        break;
                    }
                    case 0 when value > 5:
                    {
                        DelegatesExample.CreateUserWithPredefinedData userWithPredefinedData =
                            DelegatesExample.CreateManagerModel_Stat;
                        tracing.AddToTracing(counter, userWithPredefinedData);
                        Result = userWithPredefinedData();
                        break;
                    }
                    case 1 when value < 5:
                    {
                        DelegatesExample.CreateUserWithSpecialData userWithSpecialData =
                            DelegatesExample.CreateManagerModelWithParams_Stat;
                        tracing.AddToTracing(counter, userWithSpecialData);
                        Result = userWithSpecialData("Given Manager Name", 1);
                        break;
                    }
                    default:
                    {
                        DelegatesExample.CreateUserWithSpecialData userWithSpecialData =
                            DelegatesExample.CreateWorkerModelWithParams_Stat;
                        tracing.AddToTracing(counter, userWithSpecialData);
                        Result = userWithSpecialData("Given Worker Name", 13);
                        break;
                    }
                }

                switch (Result)
                {
                    case ManagerModel managerModel:
                        Console.WriteLine("Manager Name: " + managerModel._personName + "Manager Age: " +
                                          managerModel._personAge);
                        break;
                    case WorkerModel workerModel:
                        Console.WriteLine("Manager Name: " + workerModel._personName + "Manager Age: " +
                                          workerModel._personAge);
                        break;
                }

                counter++;
                Console.WriteLine("===================================");
            }

            tracing.Notify += Tracing.Display;
            // tracing.TraceON += Tracing.OnTraceOn;
            tracing.TraceON -= Tracing.OnTraceOn;
            // trace.ForEach(Console.WriteLine);
        }

        private static void CreatingHashMap()
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            var hashtable = new Hashtable { { "string", 100 } };
            var res = hashtable.Keys.Cast<List<string>>();
            Console.WriteLine(res.Select(c => c));
            Console.WriteLine(hashtable["string"]);

            HashSet<string> set = new();
            set.Add("st1");
            string actualValue = Empty;

            set.TryGetValue("st1", out actualValue);
            Console.WriteLine(actualValue);
        }

#pragma warning disable CA1416
        private static void FilteringUsageVB()
        {
            Console.WriteLine("Select Filter Straight(default 3): \n [1] - Default; [2] - 5");
            var straight = Convert.ToInt32(Console.ReadLine());
            switch (straight)
            {
                case 1:
                    straight = 3;
                    break;
                case 2:
                    straight = 5;
                    break;
                default:
                    FilteringUsageVB();
                    break;
            }

            const string partialName = "example";
            var DirectoryInWhichToSearch = new DirectoryInfo(@"C:\Users\nazar\Pictures");
            var foundFiles = DirectoryInWhichToSearch.GetFiles("*" + partialName + "*.*").ToList();
            var fileFullPath = foundFiles.Where(file => file.Extension is ".bmp" or ".jpg")
                .Select(f => f.FullName).FirstOrDefault();
            switch (IsNullOrEmpty(fileFullPath))
            {
                case false:
                {
                    Bitmap bitmap = Image.FromFile(fileFullPath) as Bitmap;
                    Bitmap result;
                    try
                    {
                        result = Filtering.MedianFilter(bitmap, straight);
                    }
                    catch
                    {
                        result = MedianFilter(bitmap, straight);
                    }
                    result.Save(@"C:\final.Png", ImageFormat.Png);
                    break;
                }
                default:
                    Console.WriteLine("No files");
                    break;
            }
        }

        private static Bitmap MedianFilter(this Bitmap sourceBitmap, int matrixSize, int bias = 0, bool grayscale = false)
        {
            var sourceData = sourceBitmap.LockBits(new Rectangle(0, 0,sourceBitmap.Width, sourceBitmap.Height),
                                                   ImageLockMode.ReadOnly,PixelFormat.Format32bppArgb);

            int arraySize = sourceData.Stride * sourceData.Height;
            var pixelBuffer = new byte[arraySize];
            
            var resultBuffer = new byte[arraySize];
            
            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0,pixelBuffer.Length);
            sourceBitmap.UnlockBits(sourceData);
            
            if (grayscale)
            {
                for (var k = 0; k < pixelBuffer.Length; k += 4)
                {
                    var rgb = pixelBuffer[k] * 0.11f;
                    rgb += pixelBuffer[k + 1] * 0.59f;
                    rgb += pixelBuffer[k + 2] * 0.3f;


                    pixelBuffer[k] = (byte)rgb;
                    pixelBuffer[k + 1] = pixelBuffer[k];
                    pixelBuffer[k + 2] = pixelBuffer[k];
                    pixelBuffer[k + 3] = 255;
                }
            }
            
            var filterOffset = (matrixSize - 1) / 2;
            var neighbourPixels = new List<int>();
            
            for (var offsetY = filterOffset;offsetY < sourceBitmap.Height - filterOffset;offsetY++)
            {
                for (var offsetX = filterOffset;offsetX < sourceBitmap.Width - filterOffset;offsetX++)
                {
                    var byteOffset = offsetY * sourceData.Stride + offsetX * 4;
                    
                    neighbourPixels.Clear();
                    for (var filterY = -filterOffset;filterY <= filterOffset;filterY++)
                    {
                        for (var filterX = -filterOffset;filterX <= filterOffset;filterX++)
                        {
                            var calcOffset = byteOffset + filterX * 4 + filterY * sourceData.Stride;
                            neighbourPixels.Add(BitConverter.ToInt32(pixelBuffer, calcOffset));
                        }
                    }

                    neighbourPixels.Sort();
                    var middlePixel = BitConverter.GetBytes(neighbourPixels[filterOffset]);
                    
                    resultBuffer[byteOffset] = middlePixel[0];
                    resultBuffer[byteOffset + 1] = middlePixel[1];
                    resultBuffer[byteOffset + 2] = middlePixel[2];
                    resultBuffer[byteOffset + 3] = middlePixel[3];
                }
            }
            var resultBitmap = new Bitmap(sourceBitmap.Width,sourceBitmap.Height);
            var resultData = resultBitmap.LockBits(new Rectangle(0, 0,resultBitmap.Width, resultBitmap.Height),
                                                   ImageLockMode.WriteOnly,PixelFormat.Format32bppArgb);
            
            Marshal.Copy(resultBuffer, 0, resultData.Scan0,resultBuffer.Length);


            resultBitmap.UnlockBits(resultData);


            return resultBitmap;
        }
    }
#pragma warning restore CA1416
}