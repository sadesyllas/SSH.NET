using System;

namespace Renci.SshNet.New.App
{
    class Program
    {
        static void Main(string[] args)
        {
            ListFiles(args[0], args[1], args[2]);
        }

        private static void ListFiles(string host, string username, string password)
        {
            string remoteDirectory = ".";

            using (SftpClient sftp = new SftpClient(host, username, password))
            {
                try
                {
                    sftp.Connect();

                    var files = sftp.ListDirectory(remoteDirectory);

                    foreach (var file in files)
                    {
                        Console.WriteLine(file.Name);
                    }

                    sftp.Disconnect();
                }
                catch (Exception e)
                {
                    Console.WriteLine("An exception has been caught " + e.ToString());
                }
            }
        }
    }
}
