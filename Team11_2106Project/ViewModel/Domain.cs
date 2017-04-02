using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team11_2106Project.ViewModel
{
    public class Data
    {
        public IEnumerable<Navbar> navbarItems()
        {
            var menu = new List<Navbar>();
            menu.Add(new Navbar { Id = 1, nameOption = "Menu1", controller = "Home", action = "Index", imageClass = "fa fa-fw fa-dashboard", estatus = true, isParent = false, parentId = 0 });
            menu.Add(new Navbar { Id = 2, nameOption = "Menu2", controller = "Home", action = "Index", imageClass = "fa fa-fw fa-bar-chart-o", estatus = true, isParent = true, parentId = 0 });
            menu.Add(new Navbar { Id = 3, nameOption = "Action", controller = "Home", action = "Dropdown", estatus = true, isParent = false, parentId = 2 });
            menu.Add(new Navbar { Id = 4, nameOption = "Another action", controller = "Home", action = "Dropdown", estatus = true, isParent = false, parentId = 2 });
            menu.Add(new Navbar { Id = 5, nameOption = "Something else here", controller = "Home", action = "Dropdown", estatus = true, isParent = false, parentId = 2 });
            

            return menu.ToList();
        }

        public IEnumerable<User> getUsers()
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, user = "admin", password = "12345", estatus = true, RememberMe = true, ourRoles = Gender.Admin });
            users.Add(new User { Id = 2, user = "candidate", password = "123456", estatus = true, RememberMe = false,ourRoles =Gender.Candidate });
            users.Add(new User { Id = 3, user = "voter", password = "1234567", estatus = false, RememberMe = false , ourRoles = Gender.Voter });
            users.Add(new User { Id = 4, user = "admin2", password = "123455", estatus = true, RememberMe = true, ourRoles = Gender.Admin });

            return users.ToList();
        }
    }
}