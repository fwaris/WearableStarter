WearableStarter
===============

An starter solution for building F# / Xamarin Android Wear applications

Overview
--------

The solution contains two projects. One is the host application that runs on the mobile device. The other is the
wearable application. For the starter project both are simple standalone applications - there is no communication between the
host and wearable apps. The main idea is to document the boilerplate required for an actual project in the form of a working
solution.

This is based on the preview version of the Xamarin Wearable package so is only valid as of this time (Nov 2014). Note:
To view preview packages you need to check the appropriate box on the Nuget browser window.

The wearable app APK is embedded as a 'raw' resource in the host APK. When the host app is deployed to a mobile device, the wearable APK is transferred 
to the companion wearable device. The host mobile device should have the "Android Wear" app installed. When you get an actual wearable
and set it up with a host device, you will be guided through the process for setting up "Android Wear".

A few pieces of metadata are needed to make sure that wearable APK is picked and transferred correctly.

First see the Google documentation for packaging wearable apps [here](http://developer.android.com/training/wearables/apps/packaging.html).
This will give you an overview of the packaging and metadata needed. Also see the [Xamarin documentation](http://developer.android.com/wear/index.html).

The Google documentation is missing a lot of little details which you may or may not be affected by. I was affected by these
and so am documenting them here in hope that it will save someone some time and grief.

Things to Watch Out For
------------------------

- Both projects should have the same Android package name and version (not sure if this required but I had issues when they differed).

- The wearable APK that is packaged in the host APK should be the 'Release' version.

- The name of the wearable APK file that is placed in the 'raw' folder should not have have upper case characters or dots ('.'). 
I used the name wearable_app.apk which seems to work fine.

- The host app should have the superset of permissions of the wearable app. If the wearable app manifest includes a permission that
is not included in the host manifest, the wearable app will not be deployed.

- Look at the AndroidManifest.xml files for both projects to see what kind of metadata entries you need for a barebones app.

- For the wearable app I had to set the Android linker to "Link all assemblies" otherwise it would not build. 
This may be something that is fixed in a newer version of the tooling.

- When developing you often deploy the app many many times. You will find that Android does not deploy to the wearable device right away.
Not sure about the reasons but maybe Android thinks that nothing has changed on the wearable as you did not go through a proper un-install/re-install cycle. 
To get around this issue, click "Resync apps". This button is found on the settings page of the "Android Wear" application on the host device. 
Allow a few minutes for the wearable APK to be transferred to the wearable device and show up there.


Debugging and Troubleshooting
-----------------------------

I had to use the Android Device Monitor extensively (for both the wearable and host devices) to resolve the various issues.

When developing the wearable app you can debug it independently from the host app. Just use Xamarin Studio to deploy and debug
the wearable project - as with any other project. For wearable apps that don't have any communication with the host app, the
entire app can be developed and debugged in this way. For apps that require host-wearable communication, first deploy a Release version 
of the wearable app via the host app and then you can deploy Debug versions directly to the wearable.

License
-------

MIT
