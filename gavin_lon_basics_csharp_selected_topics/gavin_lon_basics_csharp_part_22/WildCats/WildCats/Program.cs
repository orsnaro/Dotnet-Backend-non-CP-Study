using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace WildCats
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string content = String.Empty;
            string rootPath = AppDomain.CurrentDomain.BaseDirectory;

            try { 
                DirectoryInfo sourceDirectory = InitialiseSourceDirectory(rootPath); //TODO method
                string htmlOutputFilePath = Path.Combine(rootPath, "WildCats.html");

                FileInfo[] textFiles = sourceDirectory.GetFiles("*.txt");

                using (StreamWriter sw = new StreamWriter(htmlOutputFilePath)) {

                    AddTopHTML(sw);

                    foreach (FileInfo textFile in textFiles) {
                        using (StreamReader sr = new StreamReader(textFile.OpenRead())) { //OpenRead() returns a stream object which StreamReader needs (takes stream or string of path))
                            content = sr.ReadToEnd();
                        }
                        BuildHTMLBody(sw, content, Path.GetFileNameWithoutExtension(textFile.FullName));
                    }
                    AddBottomHTML(sw);
                }

                LaunchHTMLFileInBrowser(htmlOutputFilePath);

            } catch(UnauthorizedAccessException e) {
                LogExceptionMessageToScreen(e.Message);
                //other exception specific handling logic
            } catch (DirectoryNotFoundException e) {
                LogExceptionMessageToScreen(e.Message);
                //other exception specific handling logic
            } catch(FileNotFoundException e) {
                LogExceptionMessageToScreen(e.Message);
                //other exception specific handling logic
            } catch(IOException e) {
                LogExceptionMessageToScreen(e.Message);
                //other exception specific handling logic
            } catch(NotFiniteNumberException e) {
                LogExceptionMessageToScreen(e.Message);
                //other exception specific handling logic
            } catch(Exception e) {
                LogExceptionMessageToScreen(e.Message);
            }
        }

        private static void LogExceptionMessageToScreen(string msg) {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        private static void LaunchHTMLFileInBrowser(string url) {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
                url = url.Replace("&", "^&"); //in cmd `&` is command separator se we need to escape it using `^`
                Process.Start(new ProcessStartInfo("cmd", $"/c start {url}"));
            } else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {
                //Process.Start(new ProcessStartInfo("xdg-open", url) { UseShellExecute = false }); //not clean and uses Object Initializer
                //this is clearer:
                ProcessStartInfo procInfo = new ProcessStartInfo("xdg-open", url);
                procInfo.UseShellExecute = false; //on platforms other than win this is prefered i.e.(go use the xdg-open tool directly dont do shell commands)
                Process.Start(procInfo);
            } else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) { //macOS
                ProcessStartInfo procInfo = new ProcessStartInfo("open", url);
                procInfo.UseShellExecute = false;
                Process.Start(procInfo);
            } else {
                throw new NotImplementedException("The Application Couldn't launch your default browser!");
            }

        }

        private static void AddBottomHTML(StreamWriter sw) {
            sw.WriteLine("</div>");
            sw.WriteLine("</body>");
            sw.WriteLine("</html>");
        }


        private static void BuildHTMLBody(StreamWriter sw, string topicContent, string topicHeading) {
            sw.WriteLine($"<h3>{topicHeading}</h3>");
            sw.WriteLine($"<div>");
            sw.WriteLine($"<p>");
            sw.WriteLine(topicContent);
            sw.WriteLine($"</p>");
            sw.WriteLine("</div>");
        }
        private static void AddTopHTML(StreamWriter sw) {
            sw.WriteLine("<!doctype html>");
            sw.WriteLine(@"<html lang = ""en"">");
            sw.WriteLine("<head>");
            sw.WriteLine(@"<meta charset = ""utf-8"">");
            sw.WriteLine(@"<meta name = ""viewport"" content = ""width=device-width,intial-scale=1"">");
            sw.WriteLine("<title>Wild Cats</title>");
            sw.WriteLine(@"<link rel = ""stylesheet"" href = ""https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css"" >"); //jquery is outdated but any way lets go with the example
            sw.WriteLine(@"<script src = ""https://code.jquery.com/jquery-1.12.4.js""></script>");
            sw.WriteLine(@"<script src = ""https://code.jquery.com/ui/1.12.1/jquery-ui.js""></script>");


            //look the double $$ : escapes any single {} if needed use {{your csharp code}}
            string jQueryFunction = $$"""
                <script>
                $(function(){
                    $("#accordion").accordion();
                });
                </script>
                """;

            sw.Write(jQueryFunction);
            sw.WriteLine();
            sw.WriteLine(@"</head>");
            sw.WriteLine(@"<body>");
            sw.WriteLine(@"<h1 style=""text-align:center;font-family:arial"">Wild Cats</h1> ");
            sw.WriteLine(@"<div id = ""accordion"">");

        }
        private static DirectoryInfo InitialiseSourceDirectory(string rootPath) {
            string wildCatsDirectoryPath = Path.Combine(rootPath, "WildCatsData");
            string infoFilePath = Path.Combine(wildCatsDirectoryPath, "Information.txt");

            if (!Directory.Exists(wildCatsDirectoryPath)) {
                Directory.CreateDirectory(wildCatsDirectoryPath);
            }

            DirectoryInfo sourceDirectory = new DirectoryInfo(wildCatsDirectoryPath);

            int numTextFilesInDirectory = sourceDirectory.GetFiles("*.txt").Length;


            if (numTextFilesInDirectory == 0) {
                using StreamWriter sw = File.CreateText(infoFilePath);
                sw.WriteLine($"Text files have no yet been added to this directory: {wildCatsDirectoryPath}");
            } else if (numTextFilesInDirectory > 1 && File.Exists(infoFilePath)){
                File.Delete(infoFilePath);
            }

            return sourceDirectory;

        }
    }
}
