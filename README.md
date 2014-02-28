Database Tools
=============
Database Tools is a WinForm application written in C# for managing Microsoft SQL Server databases. It makes common tasks like backup and restore simple, without needing to know the elaborate commands or technical details to perform those operations. Each operation is referred to as a job, and you can queue up several jobs and run them synchronously. You can also save jobs to a file to run them later. The program will save the job data in XML format.

Features:

* When logging into the SQL server at startup, you can select SQL or Windows authentication. Using Windows authentication assumes the current account has rights to access the server
* Includes four basic job types: backup, restore, shrink, and copy. You can add, edit, or delete jobs as desired, and cancel job execution at any point
* Each type of job supports different kinds of tasks, such as backing up all user databases, or restoring all backups within a given directory
* Keeps track of most recently used job files
* Maintains a system log for any errors generated during job execution
* Includes a wizard for creating a SQL script for backing up selected databases
* Can be run silently from the command line, useful for running jobs within a scheduled task

   Sample command:
   dbtools.exe /jobfile:"c:\Some job file.xml" /server:myserver /auth:SQL /user:MyUserId /password:MyPassword

   If /auth:Windows is used, the account associated with the calling process is assumed to have rights to access the server.

It uses the following open source libraries:

* [Nini](http://nini.sourceforge.net)
* [DotNetZip](http://dotnetzip.codeplex.com)
* [SQL Data Access](http://sqldataaccesslib.codeplex.com)
