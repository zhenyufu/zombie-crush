using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using GameSparks.Api.Requests;

public class UserNameList : MonoBehaviour {

	public Text nt1,nt2,nt3,nt4,nt5,st1,st2,st3,st4,st5;
	public Text[] receieved = new Text[5];
	public Text[] Sreceieved = new Text[5];

	void Awake () {
		nt1.text = "N/A";
		nt2.text = "N/A";
		nt3.text = "N/A";
		nt4.text = "N/A";
		nt5.text = "N/A";

		receieved[0] = nt1;
		receieved[1] = nt2;
		receieved[2] = nt3;
		receieved[3] = nt4;
		receieved[4] = nt5;

		st1.text = "N/A";
		st2.text = "N/A";
		st3.text = "N/A";
		st4.text = "N/A";
		st5.text = "N/A";
		
		Sreceieved[0] = st1;
		Sreceieved[1] = st2;
		Sreceieved[2] = st3;
		Sreceieved[3] = st4;
		Sreceieved[4] = st5;
	}
		
	// Use this for initialization
	public void loadBoard () {


		int counter = 0;

		new LeaderboardDataRequest_hsLeaderBoard().SetEntryCount(5).Send((response) => {
			
			//what we will do with the information given by GameSparks
			foreach (var entry in response.Data)
			{
				receieved[counter].text = entry.UserName.ToString ();
				Sreceieved[counter].text = entry.GetNumberValue ("score").ToString ();
				counter++;
			}
			
		});

	}
}
