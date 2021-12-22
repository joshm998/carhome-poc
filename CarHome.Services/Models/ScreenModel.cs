using System.Collections.Generic;

namespace CarHome.Services.Models
{
    public class ScreenModel
    {
        public ScreenModel(string title, List<MenuItem> items, ScreenType screenType)
        {
            this.ScreenTitle = title;
            this.MenuItems = items;
            this.ScreenType = screenType;
        }
        public string ScreenTitle { get; set; }

        public ScreenType ScreenType { get; set; }
        public List<MenuItem> MenuItems { get; set; }
    }

    public class MenuItem
    {
        public string Title { get; set; }
        public string Api { get; set; }
        public CommandType CommandType { get; set; }
        public string Command { get; set; }
        public string Icon { get; set; }
    }

    public enum CommandType
    {
        Navigate,
        LaunchApp,
        LoadMusic,
        Play,
        Pause, 
        Next,
        Previous
    }
    public enum ScreenType
    {
        HomeScreen,
        ListView
    }
}
