using System;
using System.Collections.Generic;
using System.Text;

namespace EsrivaMobile.Models
{
    public enum MenuItemType
    {
        Home,
        About,
        Login,
        Register
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
