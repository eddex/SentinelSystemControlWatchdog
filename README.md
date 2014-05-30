SentinelSystemControlWatchdog
=============================

The Sentinel System Control process has a memory leak that occurs once in a while. This small program detects the leak and stops it by killing the process. The process will be restarted afterwards by the Sentinel Service.
