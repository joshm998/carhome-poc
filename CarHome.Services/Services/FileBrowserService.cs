using CarHome.Services.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHome.Services
{
    public class FileBrowserService
    {
        public FileBrowserService()
        {
        }

        public List<MenuItem> GetDrives()
        {
            var allDrives = DriveInfo.GetDrives();
            var removableDrives = allDrives.Where(e => e.DriveType == DriveType.Removable);
            var menuList = removableDrives
                .Select( e => new MenuItem() 
                { Command = e.RootDirectory.FullName, CommandType = CommandType.LoadMusic, Title = e.Name, Api = "Music"})
                .ToList();
            menuList.Add(new MenuItem(){ Command = "home", CommandType = CommandType.Navigate, Title = "Back", Api = "screen"});
            return menuList;
        }
    }
}
