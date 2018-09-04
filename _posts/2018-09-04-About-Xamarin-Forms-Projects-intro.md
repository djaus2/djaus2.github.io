---
layout: page
title: About Xamarin Forms Projects
subtitle: Xamarin
category: intro
date: 2018-09-04 11:32:04
---
We are looking a short-cutting getting started with Xamarin Forms for
cross platform app development, if you are already a UWP app developer.
This article discusses the rudiments of an Xamarin Forms app project
from the perspective of a UWP app developer.

 

A Xamarin Forms solution consists of a number of subprojects. There is a
target specific subproject for each chosen target, UWP, Android and IOS.
There is then one or more.NET Standard or PCL shared projects. When
built for a target, the solution uses the target's subproject and the
shared project/s. The primary shared project will contain the Xamarin
Forms pages that are common to all versions of the app. Each target
project then can contain pages and code specific to the target. For
example, when using SQLite, the target projects will contain code
generating a path to the database file that is passed up to the shared
code. In Visual Studio (2017) there are two Xamarin project templates.
The Blank template and the Master Detail template:

[***[![clip\_image002](http://embedded101.com/Portals/0/SunBlogNuke/2/Windows-Live-Writer/cf65466c8d1b_14613/clip_image002_thumb.jpg "clip_image002"){width="304"
height="315"}](http://embedded101.com/Portals/0/SunBlogNuke/2/Windows-Live-Writer/cf65466c8d1b_14613/clip_image002_2.jpg)***](http://embedded101.com/Portals/0/SunBlogNuke/2/Windows-Live-Writer/cf65466c8d1b_14613/clip_image002_2.jpg)

***The Blank Xamarin Template***

**** 

In the above project, the BlankX is the shared .NET Standard subproject
(It could be PCL). Note that that it has an XAML MainPage with its code
behind page. The start-up page by default is the MainPage in the shared
project but that can be modified in the App.xaml code page. Each of the
app targets has a separate subproject. When the app starts, the
subproject for the the specified target start and then launches the
shared project after doing any target specific initialisations.

 

***[Nb:]{.underline}*** If you create a PCL based project from the Blank
Template, the generated App.xaml and MainPage files are exactly the
same. Only the project's metainformation such as references are
different. Similarly, the code and XAML pages in the target specific
subprojects are exactly the same. The metainformation about the
projects, as specified in the subproject file (and other project
configuration files) is all that is different.

 

The Master Detail template creates a project for listing and adding
items which have some properties. The item properties are specified in
the Item class file under Models. In the Views, the MainPage
demonstrates is a tabbed page where, one tab provides a list of items
and the other shows an About content page. There is a menu item on the
MainPage for opting to add a new item. When an item in the list is
selected it is displayed in a read-only details page. When a new item is
added the NewItem page shows which is similar to the ItemDetail page
except that the item properties can be entered.

[![clip\_image004](http://embedded101.com/Portals/0/SunBlogNuke/2/Windows-Live-Writer/cf65466c8d1b_14613/clip_image004_thumb.jpg "clip_image004"){width="295"
height="484"}](http://embedded101.com/Portals/0/SunBlogNuke/2/Windows-Live-Writer/cf65466c8d1b_14613/clip_image004_2.jpg)

***The Master Detail Xamarin Template***

**** 

In the above project, the MasterD subproject is the shared .NET Standard
project. The template generates a project that implements [the MVVM
Pattern](https://msdn.microsoft.com/en-us/library/hh848246.aspx). The
XAML UI pages that are viewed in the Views folder. The start-up page is
by default the MainPage in the shared project Views folder. Data
constructs that are stored in a database, are implemented as classes in
the Models folder. Models data transforms for viewing are in the
ViewModels folder. Also, event handers for the UI pages are in the
ViewModels folder interfacing back to the models as well. Additionally,
the an Azure interface for the models is in the Services folder.

 

To create an Xamarin Forms project in Visual Studio (2017) you create a
New Project, C\#, Cross Platform, Cross Platform App (Xamarin Forms).
You get the choice of a Blank template or a Master Detail template for
the app. You get options as to which of the three platfoms (Android, IOS
and UWP) you want included in the solution., you select XF as opposed to
Native and then you select the shared code strategy (PCL (Shared
Project) or .NET Standard). Going forwards, .NET Standard is probably
the best option for the shared code. With the Master Detail template,
you also get an option to create an Azure Mobile Apps backend for the
app to provide synchronisable data storage for the app in the cloud.

[![clip\_image006](http://embedded101.com/Portals/0/SunBlogNuke/2/Windows-Live-Writer/cf65466c8d1b_14613/clip_image006_thumb.jpg "clip_image006"){width="644"
height="364"}](http://embedded101.com/Portals/0/SunBlogNuke/2/Windows-Live-Writer/cf65466c8d1b_14613/clip_image006_2.jpg)

 

### 

### About Xamarin Pages

Xamarin Forms pages are described in an XAML file with a matching code
behind C\# page, as per UWP pages. The XAML syntax is very similar
structure to UWP (and WPF) but has significant differences mainly name
changes to the XAML constructs and subtle slight differences in "the way
you do things". The code behind runs against [Mono, the cross platform
Open Source .NET Client](http://www.mono-project.com/).

***[Nb:]{.underline}*** Xamarin has relicensed the Mono runtime under
the MIT license and has contributed the code for Mono, as well as the
Xamarin SDKs for IOS and Android to the .NET Foundation. Ref:
<https://www.xamarin.com/licensing>

Note that there is a move to unify Xamarin and UWP XAML. This
unification is called XAML Standard. Here is a current comparison:

 

Xamarin Forms                     &   Windows 10 UWP    XAML

[![clip\_image008](http://embedded101.com/Portals/0/SunBlogNuke/2/Windows-Live-Writer/cf65466c8d1b_14613/clip_image008_thumb.png "clip_image008"){width="644"
height="255"}](http://embedded101.com/Portals/0/SunBlogNuke/2/Windows-Live-Writer/cf65466c8d1b_14613/clip_image008_2.png)

Read more: [Introducing XAML Standard and .NET Standard
2.0](https://d.docs.live.net/166d6b545a4e274e/Documents/Introducing%20XAML%20Standard%20and%20.NET%20Standard%202.0)

Nb: .NET Standard unifies the API across the classic, .NET Framework,
.NET Core (more APIs than original) and Xamarin (its Mono)

 
