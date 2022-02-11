﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace TestWCFService.Service
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	public class JSONServiceTrialNError : IJSONServiceTrialNError
	{
		static int check = 10;

		public JSONServiceTrialNError()
		{
			check++;
		}

		// To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
		// To create an operation that returns XML,
		//     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
		//     and include the following line in the operation body:
		//         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
		public int DoWork()
		{
			return check;
		}

		public List<SuperHero> GetAllHeros()
		{
			return Data.SuperHeroes;
		}

		public SuperHero GetHero(int id)
		{
			return Data.SuperHeroes.Find(hero => hero.Id == id);
		}

		public SuperHero AddHero(SuperHero hero)
		{
			hero.Id = Data.SuperHeroes.Max(h => h.Id) + 1;
			Data.SuperHeroes.Add(hero);
			return hero;
		}

		//public SuperHero UpdateHero(SuperHero hero) This will also work. In this case we have to update URITemplate
		public SuperHero UpdateHero(SuperHero hero, string id)
		{
			SuperHero updateHero = Data.SuperHeroes.Find(h => h.Id == int.Parse(id));
			updateHero.FirstName = hero.FirstName;
			updateHero.LastName = hero.LastName;
			updateHero.HeroName = hero.HeroName;
			updateHero.PlaceOfBirth = hero.PlaceOfBirth;
			updateHero.Combat = hero.Combat;

			return hero;
		}

		public List<SuperHero> DeleteHero(string id)
		{
			Data.SuperHeroes = Data.SuperHeroes.Where(s => s.Id != int.Parse(id)).ToList();
			return Data.SuperHeroes;
		}

		public List<SuperHero> SearchHero(string searchText)
		{
			searchText = searchText.ToLower() ?? searchText;

			List<SuperHero> sHero = Data.SuperHeroes.Where(s => s.FirstName.ToLower().Contains(searchText)
			  || s.LastName.ToLower().Contains(searchText)
			  || s.HeroName.ToLower().Contains(searchText)
			  || s.PlaceOfBirth.ToLower().Contains(searchText)
			).ToList();

			return sHero;
		}

		public List<SuperHero> GetSortedHero(string type)
		{
			List<SuperHero> SH = null;

			switch (type)
			{
				case "firstname":
					SH = Data.SuperHeroes.OrderBy(s => s.FirstName).ThenBy(s => s.LastName).ToList();
					break;

				case "lastname":
					SH = Data.SuperHeroes.OrderBy(s => s.LastName).ThenBy(s => s.FirstName).ToList();
					break;

				case "hero":
					SH = Data.SuperHeroes.OrderBy(s => s.HeroName).ToList();
					break;

				case "birthplace":
					SH = Data.SuperHeroes.OrderBy(s => s.PlaceOfBirth).ToList();
					break;

				case "combat":
					SH = Data.SuperHeroes.OrderBy(s => s.Combat).ToList();
					break;
			}

			return SH;
		}

		public string Fight(string id1, string id2)
		{
			SuperHero h1 = Data.SuperHeroes.Find(sh => sh.Id == int.Parse(id1));
			SuperHero h2 = Data.SuperHeroes.Find(sh => sh.Id == int.Parse(id2));

			if (h1.Combat > h2.Combat)
			{
				return $"{h1.HeroName} wins";
			}

			if (h1.Combat < h2.Combat)
			{
				return $"{h2.HeroName} wins";
			}

			return "It's a tie";
		}
	}
}
