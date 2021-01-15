# HomeOS-
Website that can manage devices in your home.


This application is **EXTREMELY** unfinished. There is a ton more features planned that requires some rewriting. This currently does what I need but it may not fit your needs.

## Features

### Screen Interface
A screen interface is something like a web browser accessing the site. It checks if you have a cookie with a GUID on it to tell if you are joining for the first time. If you are joining for the first time then it would ask you your preferences such as; screen timeout options and where the screen interface is located in your house.

### Dashboard
This is currently hardcoded to grab information from a Pi-hole service. In the future I will make the dashboard customizable.

### Services
This uses a lot of c# reflection that converts a class with custom attributes onto a webpage. Each property in the class can have an override name and what type of field it is so it can create HTML correctly. It automaticaly saves onto each property of the class without any extra code.

### Preferences
These are the settings that are based off your screen interface.

