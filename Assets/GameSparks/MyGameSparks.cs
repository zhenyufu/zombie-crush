using System;
using System.Collections.Generic;
using GameSparks.Core;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;

//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!
//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!
//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!

namespace GameSparks.Api.Requests{
	public class LogEventRequest_pScore : GSTypedRequest<LogEventRequest_pScore, LogEventResponse>
	{
	
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogEventResponse (response);
		}
		
		public LogEventRequest_pScore() : base("LogEventRequest"){
			request.AddString("eventKey", "pScore");
		}
		public LogEventRequest_pScore Set_score( long value )
		{
			request.AddNumber("score", value);
			return this;
		}			
	}
	
	public class LogChallengeEventRequest_pScore : GSTypedRequest<LogChallengeEventRequest_pScore, LogChallengeEventResponse>
	{
		public LogChallengeEventRequest_pScore() : base("LogChallengeEventRequest"){
			request.AddString("eventKey", "pScore");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogChallengeEventResponse (response);
		}
		
		/// <summary>
		/// The challenge ID instance to target
		/// </summary>
		public LogChallengeEventRequest_pScore SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		public LogChallengeEventRequest_pScore Set_score( long value )
		{
			request.AddNumber("score", value);
			return this;
		}			
	}
	
}
	
	
	
namespace GameSparks.Api.Requests{
	
	public class LeaderboardDataRequest_hsLeaderBoard : GSTypedRequest<LeaderboardDataRequest_hsLeaderBoard,LeaderboardDataResponse_hsLeaderBoard>
	{
		public LeaderboardDataRequest_hsLeaderBoard() : base("LeaderboardDataRequest"){
			request.AddString("leaderboardShortCode", "hsLeaderBoard");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LeaderboardDataResponse_hsLeaderBoard (response);
		}		
		
		/// <summary>
		/// The challenge instance to get the leaderboard data for
		/// </summary>
		public LeaderboardDataRequest_hsLeaderBoard SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		/// <summary>
		/// The number of items to return in a page (default=50)
		/// </summary>
		public LeaderboardDataRequest_hsLeaderBoard SetEntryCount( long entryCount )
		{
			request.AddNumber("entryCount", entryCount);
			return this;
		}
		/// <summary>
		/// A friend id or an array of friend ids to use instead of the player's social friends
		/// </summary>
		public LeaderboardDataRequest_hsLeaderBoard SetFriendIds( List<string> friendIds )
		{
			request.AddStringList("friendIds", friendIds);
			return this;
		}
		/// <summary>
		/// Number of entries to include from head of the list
		/// </summary>
		public LeaderboardDataRequest_hsLeaderBoard SetIncludeFirst( long includeFirst )
		{
			request.AddNumber("includeFirst", includeFirst);
			return this;
		}
		/// <summary>
		/// Number of entries to include from tail of the list
		/// </summary>
		public LeaderboardDataRequest_hsLeaderBoard SetIncludeLast( long includeLast )
		{
			request.AddNumber("includeLast", includeLast);
			return this;
		}
		
		/// <summary>
		/// The offset into the set of leaderboards returned
		/// </summary>
		public LeaderboardDataRequest_hsLeaderBoard SetOffset( long offset )
		{
			request.AddNumber("offset", offset);
			return this;
		}
		/// <summary>
		/// If True returns a leaderboard of the player's social friends
		/// </summary>
		public LeaderboardDataRequest_hsLeaderBoard SetSocial( bool social )
		{
			request.AddBoolean("social", social);
			return this;
		}
		/// <summary>
		/// The IDs of the teams you are interested in
		/// </summary>
		public LeaderboardDataRequest_hsLeaderBoard SetTeamIds( List<string> teamIds )
		{
			request.AddStringList("teamIds", teamIds);
			return this;
		}
		/// <summary>
		/// The type of team you are interested in
		/// </summary>
		public LeaderboardDataRequest_hsLeaderBoard SetTeamTypes( List<string> teamTypes )
		{
			request.AddStringList("teamTypes", teamTypes);
			return this;
		}
		
	}

	public class AroundMeLeaderboardRequest_hsLeaderBoard : GSTypedRequest<AroundMeLeaderboardRequest_hsLeaderBoard,AroundMeLeaderboardResponse_hsLeaderBoard>
	{
		public AroundMeLeaderboardRequest_hsLeaderBoard() : base("AroundMeLeaderboardRequest"){
			request.AddString("leaderboardShortCode", "hsLeaderBoard");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new AroundMeLeaderboardResponse_hsLeaderBoard (response);
		}		
		
		/// <summary>
		/// The number of items to return in a page (default=50)
		/// </summary>
		public AroundMeLeaderboardRequest_hsLeaderBoard SetEntryCount( long entryCount )
		{
			request.AddNumber("entryCount", entryCount);
			return this;
		}
		/// <summary>
		/// A friend id or an array of friend ids to use instead of the player's social friends
		/// </summary>
		public AroundMeLeaderboardRequest_hsLeaderBoard SetFriendIds( List<string> friendIds )
		{
			request.AddStringList("friendIds", friendIds);
			return this;
		}
		/// <summary>
		/// Number of entries to include from head of the list
		/// </summary>
		public AroundMeLeaderboardRequest_hsLeaderBoard SetIncludeFirst( long includeFirst )
		{
			request.AddNumber("includeFirst", includeFirst);
			return this;
		}
		/// <summary>
		/// Number of entries to include from tail of the list
		/// </summary>
		public AroundMeLeaderboardRequest_hsLeaderBoard SetIncludeLast( long includeLast )
		{
			request.AddNumber("includeLast", includeLast);
			return this;
		}
		
		/// <summary>
		/// If True returns a leaderboard of the player's social friends
		/// </summary>
		public AroundMeLeaderboardRequest_hsLeaderBoard SetSocial( bool social )
		{
			request.AddBoolean("social", social);
			return this;
		}
		/// <summary>
		/// The IDs of the teams you are interested in
		/// </summary>
		public AroundMeLeaderboardRequest_hsLeaderBoard SetTeamIds( List<string> teamIds )
		{
			request.AddStringList("teamIds", teamIds);
			return this;
		}
		/// <summary>
		/// The type of team you are interested in
		/// </summary>
		public AroundMeLeaderboardRequest_hsLeaderBoard SetTeamTypes( List<string> teamTypes )
		{
			request.AddStringList("teamTypes", teamTypes);
			return this;
		}
	}
}

namespace GameSparks.Api.Responses{
	
	public class _LeaderboardEntry_hsLeaderBoard : LeaderboardDataResponse._LeaderboardData{
		public _LeaderboardEntry_hsLeaderBoard(GSData data) : base(data){}
		public long? score{
			get{return response.GetNumber("score");}
		}
	}
	
	public class LeaderboardDataResponse_hsLeaderBoard : LeaderboardDataResponse
	{
		public LeaderboardDataResponse_hsLeaderBoard(GSData data) : base(data){}
		
		public GSEnumerable<_LeaderboardEntry_hsLeaderBoard> Data_hsLeaderBoard{
			get{return new GSEnumerable<_LeaderboardEntry_hsLeaderBoard>(response.GetObjectList("data"), (data) => { return new _LeaderboardEntry_hsLeaderBoard(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_hsLeaderBoard> First_hsLeaderBoard{
			get{return new GSEnumerable<_LeaderboardEntry_hsLeaderBoard>(response.GetObjectList("first"), (data) => { return new _LeaderboardEntry_hsLeaderBoard(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_hsLeaderBoard> Last_hsLeaderBoard{
			get{return new GSEnumerable<_LeaderboardEntry_hsLeaderBoard>(response.GetObjectList("last"), (data) => { return new _LeaderboardEntry_hsLeaderBoard(data);});}
		}
	}
	
	public class AroundMeLeaderboardResponse_hsLeaderBoard : AroundMeLeaderboardResponse
	{
		public AroundMeLeaderboardResponse_hsLeaderBoard(GSData data) : base(data){}
		
		public GSEnumerable<_LeaderboardEntry_hsLeaderBoard> Data_hsLeaderBoard{
			get{return new GSEnumerable<_LeaderboardEntry_hsLeaderBoard>(response.GetObjectList("data"), (data) => { return new _LeaderboardEntry_hsLeaderBoard(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_hsLeaderBoard> First_hsLeaderBoard{
			get{return new GSEnumerable<_LeaderboardEntry_hsLeaderBoard>(response.GetObjectList("first"), (data) => { return new _LeaderboardEntry_hsLeaderBoard(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_hsLeaderBoard> Last_hsLeaderBoard{
			get{return new GSEnumerable<_LeaderboardEntry_hsLeaderBoard>(response.GetObjectList("last"), (data) => { return new _LeaderboardEntry_hsLeaderBoard(data);});}
		}
	}
}	

namespace GameSparks.Api.Messages {


}
