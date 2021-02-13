# pre-hdo
Small tool for download HDO status for PRE

## WEB API (recomended)
```
GET <url>/prehdo/today - get HDO times for current day
GET <url>/prehdo/timetable - get HDO times for future (max 14 days by configuration)
```

## Console Output (deprecated)
```
                                   492 - odblokování NT, 12.02.2021 - 22.02.2021, 12.2.2021 21:08:14
-- 12.02. ------------------------------------------------------------------------------------------
       00:00 - 01:20     [01:20 - 06:20]       06:20 - 13:40     [13:40 - 16:40]       16:40 - 00:00
-- 13.02. ------------------------------------------------------------------------------------------
       00:00 - 02:00     [02:00 - 07:00]       07:00 - 13:20     [13:20 - 16:20]       16:20 - 00:00
-- 14.02. ------------------------------------------------------------------------------------------
       00:00 - 03:20     [03:20 - 08:20]       08:20 - 14:20     [14:20 - 17:20]       17:20 - 00:00
-- 15.02. -  18.02. --------------------------------------------------------------------------------
       00:00 - 01:00     [01:00 - 06:00]       06:00 - 13:00     [13:00 - 16:00]       16:00 - 00:00
-- 19.02. ------------------------------------------------------------------------------------------
       00:00 - 01:20     [01:20 - 06:20]       06:20 - 13:40     [13:40 - 16:40]       16:40 - 00:00
-- 20.02. ------------------------------------------------------------------------------------------
       00:00 - 02:00     [02:00 - 07:00]       07:00 - 13:20     [13:20 - 16:20]       16:20 - 00:00
-- 21.02. ------------------------------------------------------------------------------------------
       00:00 - 03:20     [03:20 - 08:20]       08:20 - 14:20     [14:20 - 17:20]       17:20 - 00:00
-- 22.02. ------------------------------------------------------------------------------------------
       00:00 - 01:00     [01:00 - 06:00]       06:00 - 13:00     [13:00 - 16:00]       16:00 - 00:00
```

## Configuration
```
PRE_HDO_DOWNLOAD_PERIOD_MS - HTML download period from provider URL, default 1000 * 60 * 60
PRE_HDO_DOWNLOAD_DAY_RANGE - number of another days to download, max 13 (14 with current day), default 10, 0 for current day only
PRE_HDO_COMMAND - HDO command, default 492
```
