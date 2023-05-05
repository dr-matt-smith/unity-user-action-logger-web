# unity-user-logger-web

## Accompanying project

https://github.com/dr-matt-smith/user-logger-website

## Related project

Older, CVS text file user logger (for stand-alone apps / editor games)

- https://github.com/dr-matt-smith/unity-user-action-logger

## About

Log user actions to a Web log

NOTE - only use a NUMBER for participant ID - so a specific human can never be identified from the logged data
the experiment data is then anonymised which means you can do what you like with it, including publishing it

on paper, and filed safely by _you_ the experimenter, can be a reference list of participant's personal details and their allocated user ID

something I do sometimes, so the ID doesn't even indicate the SEQUENCE of users, is to randomly allocated a number from 1-100 to each participant
(with no duplicate IDs of course)

--------
QUICK SETUP

Add package `matt-user-logger-web.unitypackage` to your project - it will add a folder to your `Assets` containing the scripts and prefab you need


--------
(1) Each scene needs a GameObject named "logsender", which has an script component of "SendToWebLog.cs"

Note - there is a prefab GameObject in the "Prefabs" folder with one of these
- so just drag this into EACH scene where you want to do some loggin

--------
(2) Each script that wants to log something must have:

- a private variable

	private SendToWebLog logSender;
	
- the following statement in the Start() method:

	public void Start()
	{
		logSender = GameObject.Find("logsender").GetComponent<SendToWebLog>();
	}


This ensures all methods in the scene now have access to a "logSender" object

--------
(3) To log a message just write the following:

	logSender.LogLine("some string message");

personally, I prefer to write this as 2 lines as follows, creating a string "message" variable:

	String message = "user clicked the HELP button";
	logSender.LogLine(message);
		
--------
(4) To set a User ID for all messages being logged, you write the following:

	logSender.NewUserId("<userIdString>");
	
this can be any string - but a participant number probably works best


--------
(5) To retrieve your logs - visit this website, with the email/password Matt assigns you:

https://user-logger.frb.io/log/

You can see logs / edit them / download all as a CSV file / delete all logs


have fun .. matt ..
p.s.
the related Symfomy website to process submissions and provide CRUD access to the logs is here:
https://github.com/dr-matt-smith/user-logger-website

