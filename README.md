SentinelSystemControlWatchdog
=============================

## What is Sentinel System Control?
The Sentinel System Control process is installed with the drivers of the MadCatz S.T.R.I.K.E.7 keyboard.

If you go to Control Panel/Programs and Features, you will see the software programs called Sentinel and Smart Technology Programming Software listed. Here is what they do:

-  Sentinel controls and monitors the two-way communication between the S.T.R.I.K.E hardware and your PC. Sentinel consists of three software processes that run on your PC.
- SentinelSystemControl keeps track of time/date and volume data and handles any adjustments you might make.

[More information here](http://support.madcatz.com/index.php?/Knowledgebase/Article/View/256)

## What's the problem?
The Sentinel System Control process has a memory leak that occurs once in a while.

## Solution
This small program detects the memory leak and stops it by killing the process. The process will be restarted afterwards by the Sentinel Service which is running in the background.
