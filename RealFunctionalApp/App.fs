namespace App
open System

module CompareVersions =

    let (|NewVersion|OldVersion|) (remoteVersion: Version, localVersion: Version) =
        if remoteVersion.CompareTo(localVersion) = 1
            && remoteVersion.Major < (localVersion.Major + 100)
            && remoteVersion.Major > localVersion.Major
            || ((remoteVersion.Major >= localVersion.Major)
            && (remoteVersion.Minor > localVersion.Minor))
            || ((remoteVersion.Major >= localVersion.Major)
            && (remoteVersion.Minor >= localVersion.Minor)
            && (remoteVersion.Build > localVersion.Build)) then
            NewVersion
        else
            OldVersion

    let compareVersion (remoteVersion: string, localVersion: string) =
        match Version.Parse(remoteVersion), Version.Parse(localVersion) with
        | NewVersion -> true
        | OldVersion -> false

    let result = compareVersion ("1.1.2.4", "1.1.3")
    
    
    let delayed timeout message =
        async{
            do! Async.Sleep timeout
            return message
        }