---
layout: page
title: Installtion of Xamarin
subtitle: Visual Studio
category: intro
date: 2018-09-04 11:24:11
---



 So we have seen the need to use Xamarin. So lets get started. This
article covers installation in Visual Studio on a Windows device

 

Installation in Visual Studio
=============================

The simplest way to install is just to select the relevant options in
the  Visual Studio installer when making a fresh installation or when
updating a current installation. Focusing upon Visual Studio 2017 Update
4 for Windows you can start the installation
[here](https://www.xamarin.com/download). There is also a Mac
installation version of Visual Studio and  Xamarin from that link,
although I haven't tried that, yet.

 

If doing a manual selection In the installer for Visual Studio, you will
want the following:

[![image](http://embedded101.com/Portals/0/SunBlogNuke/2/Windows-Live-Writer/Xamarin-for-Windows-Developers-101-Getti_FF12/image_thumb.png "image"){width="565"
height="109"}](http://embedded101.com/Portals/0/SunBlogNuke/2/Windows-Live-Writer/Xamarin-for-Windows-Developers-101-Getti_FF12/image_2.png)

and of course Xamarin:

[![image](http://embedded101.com/Portals/0/SunBlogNuke/2/Windows-Live-Writer/Xamarin-for-Windows-Developers-101-Getti_FF12/image_thumb_1.png "image"){width="284"
height="84"}](http://embedded101.com/Portals/0/SunBlogNuke/2/Windows-Live-Writer/Xamarin-for-Windows-Developers-101-Getti_FF12/image_4.png)

You will probably want Azure capabilities as well:

[![image](http://embedded101.com/Portals/0/SunBlogNuke/2/Windows-Live-Writer/Xamarin-for-Windows-Developers-101-Getti_FF12/image_thumb_2.png "image"){width="550"
height="84"}](http://embedded101.com/Portals/0/SunBlogNuke/2/Windows-Live-Writer/Xamarin-for-Windows-Developers-101-Getti_FF12/image_6.png)

 

When installing Visual Studio in Windows, there is a free Community
Edition that fully support Xamarin app development, There is also the
Professional and Enterprise versions of Visual Studio, So you may ask
what is different, what can you do, or can't do with the different
versions of VS?

[![image](http://embedded101.com/Portals/0/SunBlogNuke/2/Windows-Live-Writer/Xamarin-for-Windows-Developers-101-Getti_FF12/image_thumb_4.png "image"){width="1210"
height="602"}](http://embedded101.com/Portals/0/SunBlogNuke/2/Windows-Live-Writer/Xamarin-for-Windows-Developers-101-Getti_FF12/image_10.png)

Ref: <https://www.visualstudio.com/vs/compare/>

 

So you can do Xamarin app development with Community and Professional
version of VS but 4 features are not available:

### Embedded Assemblies

This is same as [Bundle Assemblies into Native
Code](https://developer.xamarin.com/guides/android/deployment,_testing,_and_metrics/publishing_an_application/part_1_-_preparing_an_application_for_release/#Bundle_Assemblies_into_Native_Code)
which means that when this option is enabled, assemblies are bundled
into a native shared library. This option keeps your code safe; it
protects managed assemblies by embedding them in native binaries. *Ref:*
[StackOverFlow](https://stackoverflow.com/questions/36896843/what-is-xamarin-embeded-assembly-feature-in-visual-studio-enterprise)

### Xamarin Inspector

Visualize and debug your live app: The Inspector integrates with the app
debugging workflow of your IDE, serving as a debugging or diagnostics
aid when inspecting your running app. *Ref:* [Xamarin Inspector on
developer.xamarin.com](https://developer.xamarin.com/guides/cross-platform/inspector/ "https://developer.xamarin.com/guides/cross-platform/inspector/")

### Xamarin Profiler

Xamarin uses Mono on IOS and Android for .NET runtime. Historically,
Mono has featured a powerful command-line profiler for gathering
information about programs running in the Mono runtime called the [Mono
log
profiler](http://www.mono-project.com/docs/debug+profile/profile/profiler/).
The Xamarin Profiler a graphical interface for the Mono log profiler,
and supports profiling Android, iOS, and tvOS applications on Windows.
*Ref:* [Xamarin Profile on
developer.xamarin.com](https://developer.xamarin.com/guides/cross-platform/profiler/)

### Remoted IOS Simulator for Windows

The remote iOS Simulator provides you with a way to test and debug iOS
apps on the simulator entirely from Visual Studio on Windows. The Window
displays on the VS Wiindows dev machine and can be interacted with there
(eg touch).The built code ruins on the Mac (remotely) with the UI in the
simulator  window.

*Ref:* [Remoted iOS Simulator (for
Windows)](https://developer.xamarin.com/guides/cross-platform/windows/ios-simulator/)

 

The Development Environment
===========================

Initially these articles will focus upon Xamarin Forms app development
targeting UWP. Android and IOS will come later. For UWP the dev machine
can host the app for initial testing, use an emulator (WMO or desktop)
on the desktop as well as a Windows phone.

 

Note that Android versions of the app  can be built and deployed from VS
on  Windows. The target can be an Android device or an emulator running
on the Windows device. The default emulator that is installed with the
latest version of VS is  the Google Android Emulator. This requires a 64
bit system with Hardware Virtualisation to be enabled in the system's
BIOs  for efficiency but Hyper-V needs to be disabled. Also you need to
select Intel Hardware Accelerated Execution Manager (HAXM) with the VS
installation. The emulator as well as HAXM can be selected on the
***Individual Components*** tab of  the VS Installer, under Emulators.
There is also the alternative Visual Studio Emulator for Android which
was the default emulator for VS a year or so ago. It does require
Hyper-V to be enabled. There are other Android emulators that can be
installed and used for development .. later.

 

To target a Windows (eg WMO) or a Android device it needs to be setup
for deployment, typically over USB.

-   For WMO refer to [Win 10 Phone: Universal Windows Apps Sideloading -
    Winappdeploycmd](http://www.embedded101.com/Blogs/entryid/735)
-   For Android refer to [Set Up Device for Android
    Development](https://developer.xamarin.com/guides/android/getting_started/installation/set_up_device_for_development/ "https://developer.xamarin.com/guides/android/getting_started/installation/set_up_device_for_development/")

 

With IOS, whilst you can build and deploy Xamarin apps to the simulator
as windowed on the dev desktop as discussed above, deployment to an IOS
device has to be from a Mac. Also to publish an app it has to be built
on a Mac. But this can be actioned remotely from VS on a Windows device.

 

For the initial few articles in this series, we focus upon development
on a Windows machine running VS and deploying a UWP app. Later on we
will look at Android and possibly IOS deployments in more detail

 

Some Links
==========

-   [Xamarin,com](https://www.xamarin.com/ "Xamarin")
-   [Xamarin
    University](https://university.xamarin.com/ "Xamarin University")
-   [Xamarin Forms for Windows Developers- Tips, Tricks
    and](https://www.wintellect.com/xamarin-forms-for-windows-developers-tips-tricks-and-lessons-learned-part-1/ "Xamarin Forms for Windows Developers- Tips, Tricks and")