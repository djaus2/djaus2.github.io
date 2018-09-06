---
layout: page
title: "Introduction"
subtitle: What is thi ssite about
category: intro
date: 2018-09-02 11:12:18
---


***OK so you have been creating Windows apps for ages including UWP. You
have developed apps that run on the Windows desktop and the phone. You
understand the rudiments of developing a modern UI app MVM etc. You
understand PEM, properties events and methods for classes and GUI
elements. You understand database CRUD can attach a database to an app
using formal database invocation methods. You might even have mastered
the Entity Framework and/or have a deep understanding of ORM. Overall,
in coding terms, when confronted with a new programming context you know
what you want to do and how you do with UWP or Windows Forms; you just
need to do it in the new context. Xamarin Forms, bring it on!***

 

I have previously developed an in house Windows Mobile app for data
collection. We used Lumia 640s and later on Lumia 950s purely as mobile
computing platforms, initially without SIM cards. We used these as we
could get them for about \$150 at the time and UWP was my field of
expertise. The app we developed was an in house app built from the
ground up to collect data. The data collected was a library of location
base entities. Each entity is a complex set of class instances with most
fields being scalar and some fields being a list. So the data was saved
locally and on a server when uploaded, as a relational database was a
main table list of entities with their scalar properties and keys to
secondary tables for the lists. Data such as photos was also collected
for each entity and saved as a bag. The app could collect data in the
field which when online via WiFi, could upload the collected data or
download existing data for further editing. We also implemented GPS code
to formally record the location of entities as metadata data and to also
optionally encode that information into the photos.

 

So we have been "informally" informed that Windows 10 Mobile is dead! I
have been one of the last exponents of it to jump ship; like I was with
Lance Armstrong! We have decided to rebuild the app in Xamarin Forms so
that it can run on IOS and Android phones, as well as Windows Mobile. We
will use Xamarin Forms as it's close to UWP in architecture and
methodologies. You can write most of the code in shared code used by
each of the target specific subprojects in the solution when building
for a specific target. You can also include target specific code,
usually to do with hardware or to do with target specific coding
gotchas. These can be included as conditional compiles within the shared
code or within the target specific subprojects.

 

The Data Collection App
=======================

The current structure of the app is:

1\. A main page that lists all entities stored locally

\- New entities can be added to this list, which is stored locally in a
SQLite database.

\- The list can be filtered, searched and sorted

\- The listed entities can be edited, deleted and uploaded

\- Entities can also be downloaded from the server selected via a query.
Downloaded entities can be edited and reuploaded

\- From the main page ancillary data such as photos can also be uploaded
and removed from local storage

 

2\. An edit page that implements the various data collection
functionalities.

\- Implemented as a **Tabbed Page**

\- Each **Tab** has specific functionality:

(i)    Metadata such as name, location etc.\
(ii)   A list of a data structure *with a link to a separate page 2 for editing the list*\
(iii)  A fixed list of items that can be selected (two of these tabs)\
(iv)  A list of entity specific photos *with secondary pages 4. and 5.*\
(v)   A list of notes. Each note has 
:   \- Metadata such as a title as well as properties from fixed lists
:   \- A free form multiline text field for recording the note

(vi)  A couple of topic specific tabs for 
:   \- Selecting entity properties from fixed lists
:   \- For adding additional property values specific to the entity

3\. A page for adding to or editing the items in the list *as per page 2
tab ii*

4\. A page for taking photos *as per page 2 tab iv.*

5\. A page for to view thumbnails of photos, show a full view of them as
well as to delete them *as per page 2 tab iv*

 

  ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  The current app is a UWP app with disconnected access to a cloud based server for uploading of entity data. Entity data is them processed by server based apps. A local SQLite database is used to store entity data as a relational database. It is also used store fixed data that is used in fixed lists. These tables are updatable from the server. Blob data such as photos is stored locally using the file system. Photos when uploaded to the server are transferred using a background transfer mechanism. Database connectivity is explicit using connection strings, table creation, explicit record insertion, searches, updates and deletion
  ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

 

The intention is to recreate the app using Xamarin Forms and Entity
Framework. Xamarin Forms because of the cross platform capabilities
across IOS. Android and UWP with the main functionality in shared
.NetStandard classes. EF because entity classes can be implemented in an
abstract manner.\
**PS:** Just read a query on a site wrt EF, where is the SQLite code!

 

About These Articles
====================

I have been working through the [Xamarin
University](https://www.xamarin.com/university) activities, done a few
Xamarin Hands On labs, Dev Days etc. But I want to cut to the chase a
bit quicker. In this series of articles, I will outline some of the
issues I have encountered, as a UWP app developer, in reengineering the
app in the Xamarin Forms context.\
***[Remember, I know how to do it in XAML-UWP-.NET. How do I do it in
Xamarin Forms?]{.underline}***

 

------------------------------------------------------------------------
