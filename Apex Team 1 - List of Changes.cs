variables
{
	player:
		0: Apex_General_Hero_HUD
		3: Apex_Array_HUD
		4: Apex_General_HUD
}

subroutines
{
	0: Apex_HUD
}

rule("Apex: Hud Text")
{
	event
	{
		Ongoing - Each Player;
		Team 1;
		All;
	}

	conditions
	{
		Hero Of(Event Player) != Event Player.Apex_General_Hero_HUD;
		Has Spawned(Event Player) == True;
	}

	actions
	{
		For Player Variable(Event Player, Apex_General_HUD, Count Of(Event Player.Apex_Array_HUD), 0, -1);
			Destroy HUD Text(Event Player.Apex_Array_HUD[Event Player.Apex_General_HUD - 1]);
		End;
		Event Player.Apex_Array_HUD = Empty Array;
		Event Player.Apex_General_Hero_HUD = Hero Of(Event Player);
		If(Hero Of(Event Player) == Hero(Ana));
			Start Modifying Hero Voice Lines(Event Player, 0.500, True);
			Start Scaling Player(Event Player, 1.100, True);
			Create HUD Text(Event Player, Hero Icon String(Hero(Ana)), Custom String("The Nightmare of Necropolis"), Custom String(
				"Difficulty 3/5"), Left, 0, Color(White), Color(White), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Condemn [Ability 1]"), Custom String("Ana fires a Recoiling heavy Sleep Bolt at the target enemy, Blinding them for 5 Seconds"), Left, 1, Color(White), Color(Aqua),
				Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);

			Create HUD Text(Event Player, Null, Custom String("Final Hour [Ult]"), Custom String("Ana equips Tankbuster Tracer Rounds and gains True Sight. She can Fire through Walls"), Left, 3, Color(White), Color(Aqua),
				Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
            			Create HUD Text(Event Player, Null, Custom String(""), Custom String(""), Left, 2, Color(White), Color(Aqua),
				Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);			
		End;
		If(Hero Of(Event Player) == Hero(Bastion));
			Start Modifying Hero Voice Lines(Event Player, 1.500, True);
			Start Scaling Player(Event Player, 1.100, True);
			Create HUD Text(Event Player, Hero Icon String(Hero(Bastion)), Custom String("The Machine Hearald of Paris"), Custom String(
				"Difficulty 2/5"), Left, 0, Color(White), Color(White), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Configuration: Recon [Passive]"), Custom String("In Recon mode, Bastion is fully mobile and recoils from his submachine gun"), Left, 1, Color(White), Color(Aqua),
				Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Configuration: Drone [Ability 1]"), Custom String("For 8 seconds. Gain flight and access to a gatling gun"), Left, 2, Color(White), Color(Aqua),
				Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Configuration: Tank [Ult]"), Custom String("For 16 seconds. Bastion takes 40% less Damage, moves 30% Slower and Stuns on Hit"), Left, 3, Color(White), Color(Aqua),
				Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String(""), Custom String(""), Left, 4, Color(White), Color(Aqua), Color(
				White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
		End;
		If(Hero Of(Event Player) == Hero(Junkrat));
			Start Modifying Hero Voice Lines(Event Player, 1.005, True);
			Start Scaling Player(Event Player, 1.100, True);
			Create HUD Text(Event Player, Hero Icon String(Hero(Junkrat)), Custom String("The Mad Bomber of Junkertown"), Custom String(
				"Difficulty 2/5"), Left, 0, Color(White), Color(White), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("I'm alive [Passive]"), Custom String(
				"When earning a kill with total mayhem, You rez at your location"), Left, 1, Color(White), Color(Aqua), Color(White),
				Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Ripper Air [Ability 1"), Custom String("Higher Knockback"), Left, 2, Color(White),
				Color(Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Sticky Wicket [Ability 2]"), Custom String("Now Knocks down Hunters on Trap"),
				Left, 3, Color(White), Color(Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Extra Oomph [Ultimate]"), Custom String("Riptire's speed builds up over time"),
				Left, 4, Color(White), Color(Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
		End;
		If(Hero Of(Event Player) == Hero(Widowmaker));
			Start Modifying Hero Voice Lines(Event Player, 1.030, True);
			Start Scaling Player(Event Player, 1.100, True);
			Create HUD Text(Event Player, Hero Icon String(Hero(Widowmaker)), Custom String("The Night Hunter of Château Guillard"),
				Custom String("Difficulty 4/5"), Left, 0, Color(White), Color(White), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("[Secondary Fire]"), Custom String("Filler"), Left, 1, Color(White), Color(Aqua),
				Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("[Ability 2]"), Custom String("Filler"), Left, 2, Color(White), Color(Aqua),
				Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Filler"), Custom String("Filler"), Left, 3, Color(White), Color(Aqua), Color(
				White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("[Ultimate]"), Custom String("Filler"), Left, 4, Color(White), Color(Aqua),
				Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
		End;
		If(Hero Of(Event Player) == Hero(Roadhog));
			Start Modifying Hero Voice Lines(Event Player, 0.550, True);
			Start Scaling Player(Event Player, 1.200, True);
			Create HUD Text(Event Player, Hero Icon String(Hero(Roadhog)), Custom String("The Dreadnought of Havana"), Custom String(
				"Difficulty 3/5"), Left, 0, Color(White), Color(White), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Junk Rounds [Primary Fire]"), Custom String("Primary Fire now Stuns on Hit"),
				Left, 1, Color(White), Color(Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String(" \r\n "), Custom String(""), Left, 2, Color(Blue), Color(Blue), Color(White),
				Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Fear Beyond Death [Ability 1]"), Custom String(
				"Hooking now Pulls you to Walls and Reloads your gun"), Left, 3, Color(Aqua), Color(Aqua), Color(White), Visible To and String,
				Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String(""), Custom String("Hooking while Tapping |SHIFT| will Pull Target"), Left, 4,
				Color(Blue), Color(Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String(""), Custom String(
				"Hooking while Holding |SHIFT| will Swap Postions with your Target"), Left, 5, Color(Sky Blue), Color(Aqua), Color(White),
				Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String(" \r\n "), Custom String(""), Left, 6, Color(Blue), Color(Blue), Color(White),
				Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Echoing Flames [Ability 2]"), Custom String(
				"Now Heals you over Time for more Health"), Left, 7, Color(White), Color(Aqua), Color(White), Visible To and String,
				Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Purge [Ult]"), Custom String("Ult now Roots targets"), Left, 8, Color(White),
				Color(Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
		End;
		If(Hero Of(Event Player) == Hero(Sigma));
			Start Modifying Hero Voice Lines(Event Player, 0.900, True);
			Start Scaling Player(Event Player, 1.150, True);
			Start Scaling Barriers(Event Player, 1.200, True);
			Create HUD Text(Event Player, Hero Icon String(Hero(Sigma)), Custom String("The Void Prophet of Nepal"), Custom String(
				"Difficulty 3/5"), Left, 0, Color(White), Color(White), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Void Shift [Passive]"), Custom String(
				"Fly up with |Jump| -  Fly down with |Crouch|"), Left, 1, Color(White), Color(Aqua), Color(White), Visible To and String,
				Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Void Shift [Passive]"), Custom String(
				"Hunters within 10 meters lose their Gravity"), Left, 2, Color(White), Color(Aqua), Color(White), Visible To and String,
				Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Malefic Visions of Stone [Ability 2]"), Custom String("Hold [E] to Throw up to 3 Boulders, each Stuning for 3 Seconds. Cancel with |R|"), Left,
				3, Color(White), Color(Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Call of the Void [Ult]"), Custom String(
				"Freeze Time briefly stunning all Hunters and Ult Kocking them down and Flinging them up"), Left, 4, Color(White), Color(Aqua),
				Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
		End;
		If(Hero Of(Event Player) == Hero(Reinhardt));
			Start Modifying Hero Voice Lines(Event Player, 0.680, True);
			Start Scaling Player(Event Player, 1.200, True);
			Start Scaling Barriers(Event Player, 0.800, True);
			Create HUD Text(Event Player, Hero Icon String(Hero(Reinhardt)), Custom String("The Frozen Revenant of Eichenwalde"),
				Custom String("Difficulty 1/5"), Left, 0, Color(White), Color(White), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Frozen Hammer [Primary Fire]"), Custom String("Swings now Knockdown Hunters"),
				Left, 1, Color(White), Color(Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Arctic Assault [Ability 1]"), Custom String(
				"Charge now pins multiple Hunters. Starts Slow and Builds up over 2 Seconds"), Left, 2, Color(White), Color(Aqua), Color(White),
				Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Flame Frost [Ability 2]"), Custom String(
				"Flamestrike now Freezes players Hit and anyone around them."), Left, 3, Color(White), Color(Aqua), Color(White),
				Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Fury of the North [Ult]"), Custom String(
				"Ult in a 20 Meter Circle and Knock Hunters into the Air."), Left, 4, Color(White), Color(Aqua), Color(White),
				Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
		End;
		If(Hero Of(Event Player) == Hero(Mercy));
			Start Modifying Hero Voice Lines(Event Player, 1.030, True);
			Start Scaling Player(Event Player, 1.100, True);
			Create HUD Text(Event Player, Hero Icon String(Hero(Mercy)), Custom String("The Ice Witch of Ayutthaya"), Custom String(
				"Difficulty 2/5"), Left, 0, Color(White), Color(White), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("[Melee]"), Custom String("Filler", Input Binding String(Button(Jump))), Left, 1,
				Color(White), Color(Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("[Ability 1]"), Custom String("Filler"), Left, 2, Color(White), Color(Aqua),
				Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("[Ability 2]"), Custom String("Filler"), Left, 3, Color(White), Color(Aqua),
				Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("[Ult]"), Custom String("Filler"), Left, 3, Color(White), Color(Aqua), Color(
				White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
		End;
		If(Hero Of(Event Player) == Hero(Lúcio));
			Start Modifying Hero Voice Lines(Event Player, 0.950, True);
			Start Scaling Player(Event Player, 1.100, True);
			Create HUD Text(Event Player, Hero Icon String(Hero(Lúcio)), Custom String("The Exile of Rio de Janeiro"), Custom String(
				"Difficulty 3/5"), Left, 0, Color(White), Color(White), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Urban Surfing [Passive]"), Custom String("Wall Riding is 30% Faster"), Left, 1,
				Color(White), Color(Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Boop [Secondary Fire]"), Custom String("Soundwave now Stuns Hunters on hit"),
				Left, 2, Color(White), Color(Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Crossfade [Ability 1]"), Custom String("Crossfade plays both songs at once"),
				Left, 3, Color(White), Color(Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Soundwave Guillotine [Ult]"), Custom String(
				"Ult deals damage based on Air Time. Land on a Hunter to deal Damage. 2 Meters Radius. Resets on Kill."), Left, 3, Color(
				White), Color(Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
		End;
		If(Hero Of(Event Player) == Hero(Zarya));
			Start Modifying Hero Voice Lines(Event Player, 1.010, True);
			Start Scaling Player(Event Player, 1.150, True);
			Create HUD Text(Event Player, Hero Icon String(Hero(Zarya)), Custom String("The Enforcer of Volskaya"), Custom String(
				"Difficulty 3/5"), Left, 0, Color(White), Color(White), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Relentless Force [Passive]"), Custom String(
				"When falling below 50% HP, Zarya will increase Healing Received by 300% until 100% HP"), Left, 1, Color(White), Color(Aqua),
				Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Blast Shield [Ability 2]"), Custom String(
				"Resets Cooldown of Barrier [Ability 1]"), Left, 2, Color(White), Color(Aqua), Color(White), Visible To and String,
				Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Blast Shield [Ability 2]"), Custom String(
				"Creates a Barrier and grabs the nearest Enemy dealing low Damage"), Left, 3, Color(White), Color(Aqua), Color(White),
				Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
		End;
		If(Hero Of(Event Player) == Hero(Tracer));
			Start Modifying Hero Voice Lines(Event Player, 1.010, True);
			Start Scaling Player(Event Player, 1.100, True);
			Create HUD Text(Event Player, Hero Icon String(Hero(Tracer)), Custom String("The Bounty Hunter of King's Row"), Custom String(
				"Difficulty 4/5"), Left, 0, Color(White), Color(White), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Timewinder [Passive]"), Custom String("Press |Jump| to perform a Double Jump"),
				Left, 1, Color(White), Color(Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String(" Parallel Convergence [Primary Fire]"), Custom String(
				"Dealing Damage Heals 1% Health"), Left, 2, Color(White), Color(Aqua), Color(White), Visible To and String,
				Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Phase Dive [Ability 1]"), Custom String("Blink Recharges Faster"), Left, 3,
				Color(White), Color(Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Chronobreak [Ability 2]"), Custom String(
				"Tap |E| to perform a Recall + 50 Health. Hold |E| to perform an Extended Recall + 150 Health"), Left, 4, Color(White), Color(
				Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Double Up [Ult]"), Custom String("Pulsebomb now deals + 75 Shrapnel Damage"),
				Left, 5, Color(White), Color(Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
		End;
		If(Hero Of(Event Player) == Hero(Cassidy));
			Start Modifying Hero Voice Lines(Event Player, 0.990, True);
			Start Scaling Player(Event Player, 1.100, True);
			Create HUD Text(Event Player, Hero Icon String(Hero(Cassidy)), Custom String("The Outlaw of Route 66"), Custom String(
				"Difficulty 2/5"), Left, 0, Color(White), Color(White), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Collateral Damage [Secondary Fire"), Custom String(
				"Stand still and rapidly fire your gun"), Left, 2, Color(White), Color(Aqua), Color(White), Visible To and String,
				Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Quick Draw [Ability 1]"), Custom String("Roll now Phases you out"), Left, 3,
				Color(White), Color(Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Smoke Screen [Ability 2]"), Custom String("Flash bang now Blinds players"),
				Left, 4, Color(White), Color(Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("New Destiny [Ult]"), Custom String(
				"Force Root everyone. After 4 seconds in Ult gain High Damage for the remainder"), Left, 5, Color(White), Color(Aqua), Color(
				White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("End of the Line [Primary Fire]"), Custom String(
				"Your last Shot deals incredible Damage"), Left, 1, Color(White), Color(Aqua), Color(White), Visible To and String,
				Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
		End;
		If(Hero Of(Event Player) == Hero(Reaper));
			Start Modifying Hero Voice Lines(Event Player, 0.550, True);
			Start Scaling Player(Event Player, 1.100, True);
			Create HUD Text(Event Player, Hero Icon String(Hero(Reaper)), Custom String("The Sydney Harbor Ripper"), Custom String(
				"Difficulty 3/5"), Left, 0, Color(White), Color(White), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Phantom Dive [Ability 1]"), Custom String(
				"Drop Physical From and Move through Walls and Fly"), Left, 1, Color(White), Color(Aqua), Color(White), Visible To and String,
				Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Phantom Gift [Ability 2]"), Custom String("Teleport and Refill your Ammo"),
				Left, 2, Color(White), Color(Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Death from Below [Ult]"), Custom String(
				"Drop a Biotic Grenade at your feet and Death Blossom"), Left, 3, Color(White), Color(Aqua), Color(White),
				Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
		End;
		If(Hero Of(Event Player) == Hero(D.Va));
			Start Modifying Hero Voice Lines(Event Player, 1.100, True);
			Start Scaling Player(Event Player, 1.150, True);
			Create HUD Text(Event Player, Hero Icon String(Hero(D.Va)), Custom String("The Mechanized Menace of Busan"), Custom String("3/5"),
				Left, 0, Color(White), Color(White), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Filler [Ability 1]"), Custom String("Filler"), Left, 1, Color(White), Color(
				Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Filler [Ability 2]"), Custom String("Filler"), Left, 2, Color(White), Color(
				Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Filler"), Custom String("Filler"), Left, 3, Color(White), Color(Aqua), Color(
				White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Filler [Ultimate]"), Custom String("Filler"), Left, 4, Color(White), Color(
				Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
		End;
		If(Hero Of(Event Player) == Hero(Orisa));
			Start Modifying Hero Voice Lines(Event Player, 0.700, True);
			Start Scaling Player(Event Player, 1.200, True);
			Create HUD Text(Event Player, Hero Icon String(Hero(Orisa)), Custom String("The Iron Maiden of Numbani"), Custom String(
				"Difficulty 4/5"), Left, 0, Color(White), Color(White), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Filler"), Custom String("Filler"), Left, 1, Color(White), Color(Aqua),
				Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Filler [Secondary Fire]"), Custom String("Charge", Input Binding String(Button(
				Jump))), Left, 2, Color(White), Color(Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Hammer of Dawn [Ult]"), Custom String("Filler"), Left, 3, Color(White), Color(
				Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String(""), Custom String(""), Left, 4, Color(White), Color(
				Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);            
		End;
		If(Hero Of(Event Player) == Hero(Pharah));
			Start Modifying Hero Voice Lines(Event Player, 1.010, True);
			Start Scaling Player(Event Player, 1.100, True);
			Create HUD Text(Event Player, Hero Icon String(Hero(Pharah)), Custom String("The Sheriff of Anubis"), Custom String(
				"Difficulty 3/5"), Left, 0, Color(White), Color(White), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Valkyrie [Secondary Fire]"), Custom String("Now only allows Hovering"), Left, 1,
				Color(White), Color(Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Vault Breaker [Ability 1]"), Custom String(
				"Surge forward at your Crosshair. Landing after Vault Breaker will Knockdown Hunters in 5 Meters"), Left, 2, Color(White),
				Color(Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String(""), Custom String(""), Left, 5, Color(White), Color(Aqua), Color(White),
				Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String(""), Custom String(""), Left, 4, Color(White), Color(Aqua), Color(White),
				Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Ace in the Hole [Ult]"), Custom String(
				"Rockets travel Faster and deal bonus Damage"), Left, 3, Color(White), Color(Aqua), Color(White), Visible To and String,
				Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
		End;
		If(Hero Of(Event Player) == Hero(Genji));
			Start Modifying Hero Voice Lines(Event Player, 0.900, True);
			Start Scaling Player(Event Player, 1.100, True);
			Create HUD Text(Event Player, Hero Icon String(Hero(Genji)), Custom String("The Unforgotten of Lijiang"), Custom String(
				"Difficulty 5/5"), Left, 0, Color(White), Color(White), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Fate Sealed"), Custom String(
				"Genji wields an ancient weapon that battles with him for control.\r\nOnce your ult is filled, Genji will be given a choice \r\n\r\n \r\n"),
				Left, 1, Color(White), Color(Purple), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("|| Shounobi Form ||"), Custom String(" "), Left, 2, Color(Aqua), Color(Aqua),
				Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Way of the Hunter [Melee]"), Custom String("Press |Melee| to drop a smoke bomb"),
				Left, 3, Color(White), Color(Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Soul Unbound [Ability 1"), Custom String(
				"Hold |Shift| and |Jump| to Dash through walls"), Left, 4, Color(White), Color(Aqua), Color(White), Visible To and String,
				Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String(""), Custom String(" \r\n "), Left, 5, Color(White), Color(Gray), Color(White),
				Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("|| Demon Form ||"), Custom String(" "), Left, 6, Color(White), Color(Red),
				Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Umbral Trespass [Ability 1"), Custom String("Dash leaves a DOT"), Left, 7,
				Color(White), Color(Red), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Shadow Step [Ability 2]"), Custom String("Deflect makes you Phased out"), Left,
				7, Color(White), Color(Red), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
		End;
		If(Hero Of(Event Player) == Hero(Brigitte));
			Start Modifying Hero Voice Lines(Event Player, 1.020, True);
			Start Scaling Player(Event Player, 1.100, True);
			Create HUD Text(Event Player, Hero Icon String(Hero(Brigitte)), Custom String("Filler"), Custom String("Difficulty 2/5"), Left, 0,
				Color(White), Color(White), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Filler"), Custom String("Filler"), Left, 1, Color(White), Color(Aqua), Color(
				White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Filler [Ability 1]"), Custom String("Filler"), Left, 2, Color(White), Color(
				Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Filler [Ability 2]"), Custom String("Filler"), Left, 3, Color(White), Color(
				Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Filler [Interact]"), Custom String("Filler"), Left, 4, Color(White), Color(
				Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
		End;
		If(Hero Of(Event Player) == Hero(Torbjörn));
			Start Modifying Hero Voice Lines(Event Player, 0.700, True);
			Start Scaling Player(Event Player, 1.100, True);
			Create HUD Text(Event Player, Hero Icon String(Hero(Torbjörn)), Custom String("The Madman of Gothenburg"), Custom String(
				"Difficulty 1/5"), Left, 0, Color(White), Color(White), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Undying [Passive]"), Custom String(
				"When you Die become Unkillable for 7 Seconds after which you Die. Deal Double Damage during this."), Left, 1, Color(White),
				Color(Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Filler"), Custom String("Filler"), Left, 2, Color(White), Color(Aqua), Color(
				White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Filler [Ability 1]"), Custom String("Filler"), Left, 3, Color(White), Color(
				Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Filler"), Custom String("Filler"), Left, 4, Color(White), Color(Aqua), Color(
				White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
		End;
		Call Subroutine(Apex_HUD);
	}
}

rule("Apex: Hud Text 2")
{
	event
	{
		Subroutine;
		Apex_HUD;
	}

	actions
	{
		If(Hero Of(Event Player) == Hero(Zenyatta));
			Start Modifying Hero Voice Lines(Event Player, 0.500, True);
			Start Scaling Player(Event Player, 1.100, True);
			Create HUD Text(Event Player, Hero Icon String(Hero(Zenyatta)), Custom String("The Void Walker of Petra"), Custom String(
				"Difficulty 2/5"), Left, 0, Color(White), Color(White), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Force Pulse [Melee]"), Custom String("Melee now pushes Hunters back"), Left, 1,
				Color(White), Color(Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Harmony [Reload]"), Custom String("Balance between Yin and Yang. Normal Stats"),
				Left, 2, Color(White), Color(Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Yang [Ability 1]"), Custom String(
				"Increased Healing and Damage Reduction. At the cost of Damage and Speed"), Left, 3, Color(White), Color(Aqua), Color(White),
				Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Yin [Ability 2]"), Custom String(
				"Increase Damage and Speed. At the cost of Damage Reduction and Healing"), Left, 4, Color(White), Color(Aqua), Color(White),
				Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Null Sphere of the Void [Ultimate]"), Custom String(
				"Become a Black Hole. Pulling all nearby Hunters towards you and creating a field of gravitational force around you"), Left, 5,
				Color(White), Color(Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
		End;
		If(Hero Of(Event Player) == Hero(Soldier: 76));
			Start Modifying Hero Voice Lines(Event Player, 0.920, True);
			Start Scaling Player(Event Player, 1.100, True);
			Create HUD Text(Event Player, Hero Icon String(Hero(Soldier: 76)), Custom String("The Crimson Reaper of Hollywood"), Custom String(
				"Difficulty 3/5"), Left, 0, Color(White), Color(White), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Transfusion [Primary Fire]"), Custom String(
				"Soldier 76 syphons blood over 10 seconds from the target enemy, Damages target and Heals himself"), Left, 1, Color(White), Color(
				Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Large Casing [Secondary Fire]"), Custom String("Now fires 2 Charges that deal Knockdown"), Left, 2,
				Color(White), Color(Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Sanguine Cloud [Ability 1"), Custom String("Turn Invisible and move Faster"),
				Left, 3, Color(White), Color(Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Hemostasis [Ult]"), Custom String(
				"Become a Perfect Scion and gain 100% Life Steal"), Left, 4, Color(White), Color(Aqua), Color(White), Visible To and String,
				Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String(""), Custom String(""), Left, 5, Color(White), Color(Aqua), Color(White),
				Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
		End;
		If(Hero Of(Event Player) == Hero(Sombra));
			Start Modifying Hero Voice Lines(Event Player, 1.010, True);
			Start Scaling Player(Event Player, 1.100, True);
			Create HUD Text(Event Player, Hero Icon String(Hero(Sombra)), Custom String("The Rogue Assassin of Dorado"), Custom String(
				"Difficulty 2/5"), Left, 0, Color(White), Color(White), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Hijack [Passive]"), Custom String(
				"When you Hack a Target, Steal 25% of their Ult Charge"), Left, 1, Color(White), Color(Aqua), Color(White),
				Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Twilight Shroud [Ability 1]"), Custom String(
				"Turn Invisible, move Faster and become Lighter"), Left, 3, Color(White), Color(Aqua), Color(White), Visible To and String,
				Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Perfect Execution [Ult]"), Custom String("Now deals 75% of Hunters Health"),
				Left, 4, Color(White), Color(Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Five Point Strike [Melee]"), Custom String(
				"Melee hits from behind deal bonus Damage and Knockdown Targets - CD 5 Seconds"), Left, 2, Color(White), Color(Aqua), Color(White),
				Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
		End;
		If(Hero Of(Event Player) == Hero(Moira));
			Start Modifying Hero Voice Lines(Event Player, 1.030, True);
			Start Scaling Player(Event Player, 1.100, True);
			Create HUD Text(Event Player, Hero Icon String(Hero(Moira)), Custom String("Daughter of the Void"), Custom String("Difficulty 3/5"),
				Left, 0, Color(White), Color(White), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Void Hold [Crouch]"), Custom String("Crouching before firing Biotic Orbs will hold them in place"), Left, 1, Color(White), Color(Aqua), Color(
				White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);            
			Create HUD Text(Event Player, Null, Custom String("Icathian Rain [Primary Fire]"), Custom String("Moira fires flames through her sleeve, deaing DOT Damage"), Left, 2, Color(White), Color(Aqua),
				Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Void Seeker [Abillity 1]"), Custom String("Tap |Shift| to perform a Fade - CD 3 Seconds. Hold |Shift| to perform an Extended Fade - CD 8 Seconds"), Left, 3, Color(White), Color(Aqua),
				Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Supercharge [Ability 2]"), Custom String("Fire out 3 Biotic Orbs at High Speed"), Left, 4, Color(White), Color(Aqua),
				Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Killer Instinct"), Custom String("Moira briefly Freezes Time and roots in place. During which she charges her Coalescence for extreme Damage"), Left, 5, Color(White), Color(Aqua), Color(
				White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
		End;
		If(Hero Of(Event Player) == Hero(Winston));
			Start Modifying Hero Voice Lines(Event Player, 0.700, True);
			Start Scaling Player(Event Player, 1.190, True);
			Start Scaling Barriers(Event Player, 2, True);
			Create HUD Text(Event Player, Hero Icon String(Hero(Winston)), Custom String("The Monkey King of Gibraltar"), Custom String(
				"Difficulty 3/5"), Left, 0, Color(White), Color(White), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String(" \r\n "), Custom String(""), Left, 1, Color(Blue), Color(Blue), Color(White),
				Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Hop [Ability 1]"), Custom String("Hold |SHIFT| before Jumping to Hop Farther"),
				Left, 2, Color(White), Color(Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Hop [Ability 1]"), Custom String("Tap |SHIFT| to perform a short Hop"), Left, 3,
				Color(White), Color(Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Hop [Ability 1]"), Custom String("Hold |SHIFT| after Jumping to Hop Higher"),
				Left, 4, Color(White), Color(Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String(" \r\n "), Custom String(""), Left, 5, Color(Blue), Color(Blue), Color(White),
				Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Slam! [Ability 1]"), Custom String(
				"Winston deals Bonus Damage to players he Lands on"), Left, 6, Color(White), Color(Aqua), Color(White), Visible To and String,
				Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String(""), Custom String(""), Left, 7, Color(White), Color(Aqua), Color(White),
				Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Mega Monkey [Ultimate]"), Custom String(
				"Regen all Health and go into Stage 2. Last Forever"), Left, 8, Color(White), Color(Aqua), Color(White), Visible To and String,
				Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
		End;
		If(Hero Of(Event Player) == Hero(Doomfist));
			Start Modifying Hero Voice Lines(Event Player, 0.850, True);
			Start Scaling Player(Event Player, 1.100, True);
			Create HUD Text(Event Player, Hero Icon String(Hero(Doomfist)), Custom String("The Unshackled of Rialto"), Custom String(
				"Difficulty 4/5"), Left, 0, Color(White), Color(White), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Haymaker [Secondary Fire]"), Custom String(
				"Move at full Movespeed, travels further at the direction of your Crosshair"), Left, 1, Color(White), Color(Aqua), Color(White), Visible To and String,
				Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Facebreaker [Ability 1]"), Custom String("Uppercut now tavels Higher and Lowers Gravity"), Left, 2,
				Color(White), Color(Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Knuckle Down [Ability 2]"), Custom String(
				"Deals bonus Damage based on Airtime"), Left, 3, Color(White), Color(Aqua), Color(White), Visible To and String,
				Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("The Show Stopper [Ult]"), Custom String(
				"Ult Only last for 3 Seconds. Killing a Hunter gives you 100% Ult"), Left, 4, Color(White), Color(Aqua), Color(White),
				Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
		End;
		If(Hero Of(Event Player) == Hero(Mei));
			Start Modifying Hero Voice Lines(Event Player, 1.040, True);
			Start Scaling Player(Event Player, 1.100, True);
			Create HUD Text(Event Player, Hero Icon String(Hero(Mei)), Custom String("The Cryophoenix of Antarctica"), Custom String(
				"Difficulty 2/5"), Left, 0, Color(White), Color(White), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("[Primary Fire]"), Custom String("Filler"), Left, 1, Color(White), Color(Aqua),
				Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("[Ability 1]"), Custom String("Filler"), Left, 2, Color(White), Color(Aqua),
				Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("[Ability 2]"), Custom String("Filler"), Left, 3, Color(White), Color(Aqua),
				Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Filler"), Custom String("Filler"), Left, 4, Color(White), Color(Aqua), Color(
				White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
		End;
		If(Hero Of(Event Player) == Hero(Hanzo));
			Start Modifying Hero Voice Lines(Event Player, 0.820, True);
			Start Scaling Player(Event Player, 1.100, True);
			Create HUD Text(Event Player, Hero Icon String(Hero(Hanzo)), Custom String("The Unforgiven of Hanamura"), Custom String(
				"Difficulty 3/5"), Left, 0, Color(White), Color(White), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Piercing Arrow"), Custom String(
				"Now Stuns on Hit. Headshots will Knockdown and Push Hunters"), Left, 2, Color(White), Color(Aqua), Color(White),
				Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Hail of Arrows [Ability 2]"), Custom String("Deals Bleed Damage and Heals you"),
				Left, 3, Color(White), Color(Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Corruption [Passive]"), Custom String("Arrows now have 0% Gravity"), Left, 1,
				Color(White), Color(Aqua), Color(White), Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
			Create HUD Text(Event Player, Null, Custom String("Blighted Quiver [Ult]"), Custom String(
				"Shoot 3 Dragon Arrows over 3 seconds. Does not Stack"), Left, 4, Color(White), Color(Aqua), Color(White),
				Visible To and String, Default Visibility);
			Modify Player Variable(Event Player, Apex_Array_HUD, Append To Array, Last Text ID);
		End;
	}
}