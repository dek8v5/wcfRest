using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfREST
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        static List<Team> team; 
		
		static Service1(){
			team = new List<Team>();
		}

		//get all team list (done)
        public IEnumerable<Team> GetTeams()
        {
            return team;
        }


        //getTeam method
        public Team GetTeam(string name)
        {
            //checked whether the team is there or not
            Team myteam = team.Find(t => t.Name == name);
			
			if (myteam == null) 
				return null;

            return myteam;
        }

        //addTeam method (done)
        public void AddTeam(string Name, string City, Stadium stadium)
        {
            //create new team
            Team teams = new Team();
            //initialize the the variable
            teams.Name = Name;
            teams.City = City;
            teams.HomeStadium = stadium;
            teams.Players = new List<Player>();
            //add the new team into the list
            team.Add(teams);
        }

        //updateTeam method
        public void UpdateTeam(string Name, string City, Stadium stadium)
        {
            //checked whether the team is there or not
            Team teamUpdate = team.Find(t => t.Name == Name);
			
			if (teamUpdate == null) 
				return;
			
            //update the attributes
            teamUpdate.HomeStadium = stadium;
            teamUpdate.City = City;
        }

        //deleteTeam method (done)
        public void DeleteTeam()
        {
            team.Clear();
        }

        //get the players method
        public IEnumerable<Player> GetTeamPlayer(string name)
        {
            //checked whether the team is there or not
            Team myteam = team.Find(t => t.Name == name);
			if (myteam == null) 
				return null;
			return myteam.Players;
        }

        //get the stadium info method
        public Stadium GetTeamStadium(string name)
        {
            //checked whether the team is there or not
            Team myteam = team.Find(t => t.Name == name);
			if (myteam == null) 
				return null;
            return myteam.HomeStadium;
        }

        //add team player method
        public void AddTeamPlayer(string name, List<Player> players)
        {
            //checked whether the team is there or not
            Team myteam = team.Find(t => t.Name == name);

            foreach (var newPlayer in players)
            {
                myteam.Players.Add(newPlayer);
            }



        }
    }
}