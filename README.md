# HomeOS-
Website that can manage devices in your home.


This application is **EXTREMELY** unfinished. There is a ton more features planned that requires some rewriting. This currently does what I need but it may not fit your needs.

### Uses
I am currently running this application on a raspberry pi 4 model A using a 7" touchscreen. I have it set up where I can access the pi's website from any other device in the house using nginx. It also has Pi-hole enabled and set to another raspberry pi on my local network on the services page.

## Features

### Screen Interface
A screen interface is something like a web browser accessing the site. It checks if you have a cookie with a GUID on it to tell if you are joining for the first time. If you are joining for the first time then it would ask you your preferences such as; screen timeout options and where the screen interface is located in your house.

### Dashboard
This is currently hardcoded to grab information from a Pi-hole service. In the future I will make the dashboard customizable.

### Services
This uses a lot of c# reflection that converts a class with custom attributes onto a webpage. Each property in the class can have an override name and what type of field it is so it can create HTML correctly. It automaticaly saves onto each property of the class without any extra code.

### AFK Screen
If you haven't interacted with the web page for a set amount of time that you can change in your preferences, you will be taken to a screen that will display the time/date or both depending on your preference settings. This mimics the screen from Nest Hubs whenever you don't interact with them.

### Preferences
These are the settings that are based off your screen interface.

