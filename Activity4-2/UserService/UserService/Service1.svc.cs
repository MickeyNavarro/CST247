using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace UserService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        Random random = new Random(); 
        List<User> userList = new List<User>(); 

        public Service1()
        {
            //List<int> listOfScores = GetSomeRandomScores(random);

            User u1 = new User(1, "Mickey", true, 92000, GetSomeRandomScores(random));
            User u2 = new User(2, "Minnie", true, 98363, GetSomeRandomScores(random));
            User u3 = new User(3, "Donald", false, 27635, GetSomeRandomScores(random));
            User u4 = new User(4, "Goofy", true, 83632, GetSomeRandomScores(random));
            User u5 = new User(5, "Pluto", false, 3762, GetSomeRandomScores(random));

            userList.Add(u1);
            userList.Add(u2);
            userList.Add(u3);
            userList.Add(u4);
            userList.Add(u5);

        }

        private static List<int> GetSomeRandomScores(Random r)
        {
            List<int> listOfScores = new List<int>();
            for(int i = 0; i<r.Next(10); i++)
            {
                listOfScores.Add(r.Next(100)); 
            }
            return listOfScores;
        }

        public string GetData(string value)
        {
            return string.Format("You entered: {0}", value);
        }
         
        /*public List<User> GetAllUsers()
        {
            return userList; 
        }*/

        public UserDTO GetAllUsers()
        {
            UserDTO userDTO = new UserDTO();
            userDTO.MessageCode = 1;
            userDTO.MessageText = "Everybody is here";
            userDTO.userList = userList; 
            return userDTO;
        }

        public UserDTO GetUsersById(string id)
        {
            UserDTO userDTO = new UserDTO();

            List<User> returnThesePeople = userList.Where(x => x.Id == Int32.Parse(id)).ToList();

            userDTO.userList = returnThesePeople;
            userDTO.MessageCode = returnThesePeople.Count;
            userDTO.MessageText = "The people who have a '" + id + "' as their ID number.";
            return userDTO;
        }

        public UserDTO GetUsersByName(string name)
        {
            UserDTO userDTO = new UserDTO();

            List<User> returnThesePeople = userList.Where(x=>x.Name.ToLower().Contains(name.ToLower())).ToList();
            //where = filter that allows you to find certain things
            //return a list of users where user x has a name that contains the given string 
            // ToLower = not case sensitive

            userDTO.userList = returnThesePeople;
            userDTO.MessageCode = returnThesePeople.Count;
            userDTO.MessageText = "The people who have a '" + name + "' in their name.";
            return userDTO; 
        }
    }
}
