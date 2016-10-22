//   !!  // Steamworks.Core - SteamEnums.cs
// *.-". // Created: 2016-10-17 [11:09 PM]
//  | |  // Copyright 2016 // MIT License // The Fox Council 
// Modified by: Fox Diller on 2016-10-22 @ 3:03 PM

namespace Steamworks.Core
{
    // ReSharper disable InconsistentNaming

    public enum EUniverse
    {
        k_EUniverseInvalid = 0,
        k_EUniversePublic = 1,
        k_EUniverseBeta = 2,
        k_EUniverseInternal = 3,
        k_EUniverseDev = 4,
        k_EUniverseMax = 5
    }

    public enum EResult
    {
        k_EResultOK = 1,
        k_EResultFail = 2,
        k_EResultNoConnection = 3,
        k_EResultInvalidPassword = 5,
        k_EResultLoggedInElsewhere = 6,
        k_EResultInvalidProtocolVer = 7,
        k_EResultInvalidParam = 8,
        k_EResultFileNotFound = 9,
        k_EResultBusy = 10,
        k_EResultInvalidState = 11,
        k_EResultInvalidName = 12,
        k_EResultInvalidEmail = 13,
        k_EResultDuplicateName = 14,
        k_EResultAccessDenied = 15,
        k_EResultTimeout = 16,
        k_EResultBanned = 17,
        k_EResultAccountNotFound = 18,
        k_EResultInvalidSteamID = 19,
        k_EResultServiceUnavailable = 20,
        k_EResultNotLoggedOn = 21,
        k_EResultPending = 22,
        k_EResultEncryptionFailure = 23,
        k_EResultInsufficientPrivilege = 24,
        k_EResultLimitExceeded = 25,
        k_EResultRevoked = 26,
        k_EResultExpired = 27,
        k_EResultAlreadyRedeemed = 28,
        k_EResultDuplicateRequest = 29,
        k_EResultAlreadyOwned = 30,
        k_EResultIPNotFound = 31,
        k_EResultPersistFailed = 32,
        k_EResultLockingFailed = 33,
        k_EResultLogonSessionReplaced = 34,
        k_EResultConnectFailed = 35,
        k_EResultHandshakeFailed = 36,
        k_EResultIOFailure = 37,
        k_EResultRemoteDisconnect = 38,
        k_EResultShoppingCartNotFound = 39,
        k_EResultBlocked = 40,
        k_EResultIgnored = 41,
        k_EResultNoMatch = 42,
        k_EResultAccountDisabled = 43,
        k_EResultServiceReadOnly = 44,
        k_EResultAccountNotFeatured = 45,
        k_EResultAdministratorOK = 46,
        k_EResultContentVersion = 47,
        k_EResultTryAnotherCM = 48,
        k_EResultPasswordRequiredToKickSession = 49,
        k_EResultAlreadyLoggedInElsewhere = 50,
        k_EResultSuspended = 51,
        k_EResultCancelled = 52,
        k_EResultDataCorruption = 53,
        k_EResultDiskFull = 54,
        k_EResultRemoteCallFailed = 55,
        k_EResultPasswordUnset = 56,
        k_EResultExternalAccountUnlinked = 57,
        k_EResultPSNTicketInvalid = 58,
        k_EResultExternalAccountAlreadyLinked = 59,
        k_EResultRemoteFileConflict = 60,
        k_EResultIllegalPassword = 61,
        k_EResultSameAsPreviousValue = 62,
        k_EResultAccountLogonDenied = 63,
        k_EResultCannotUseOldPassword = 64,
        k_EResultInvalidLoginAuthCode = 65,
        k_EResultAccountLogonDeniedNoMail = 66,
        k_EResultHardwareNotCapableOfIPT = 67,
        k_EResultIPTInitError = 68,
        k_EResultParentalControlRestricted = 69,
        k_EResultFacebookQueryError = 70,
        k_EResultExpiredLoginAuthCode = 71,
        k_EResultIPLoginRestrictionFailed = 72,
        k_EResultAccountLockedDown = 73,
        k_EResultAccountLogonDeniedVerifiedEmailRequired = 74,
        k_EResultNoMatchingURL = 75,
        k_EResultBadResponse = 76,
        k_EResultRequirePasswordReEntry = 77,
        k_EResultValueOutOfRange = 78,
        k_EResultUnexpectedError = 79,
        k_EResultDisabled = 80,
        k_EResultInvalidCEGSubmission = 81,
        k_EResultRestrictedDevice = 82,
        k_EResultRegionLocked = 83,
        k_EResultRateLimitExceeded = 84,
        k_EResultAccountLoginDeniedNeedTwoFactor = 85,
        k_EResultItemDeleted = 86,
        k_EResultAccountLoginDeniedThrottle = 87,
        k_EResultTwoFactorCodeMismatch = 88,
        k_EResultTwoFactorActivationCodeMismatch = 89,
        k_EResultAccountAssociatedToMultiplePartners = 90,
        k_EResultNotModified = 91,
        k_EResultNoMobileDevice = 92,
        k_EResultTimeNotSynced = 93,
        k_EResultSmsCodeFailed = 94,
        k_EResultAccountLimitExceeded = 95,
        k_EResultAccountActivityLimitExceeded = 96,
        k_EResultPhoneActivityLimitExceeded = 97,
        k_EResultRefundToWallet = 98,
        k_EResultEmailSendFailure = 99,
        k_EResultNotSettled = 100,
        k_EResultNeedCaptcha = 101,
        k_EResultGSLTDenied = 102,
        k_EResultGSOwnerDenied = 103,
        k_EResultInvalidItemType = 104,
        k_EResultIPBanned = 105,
        k_EResultGSLTExpired = 106
    }

    public enum EVoiceResult
    {
        k_EVoiceResultOK = 0,
        k_EVoiceResultNotInitialized = 1,
        k_EVoiceResultNotRecording = 2,
        k_EVoiceResultNoData = 3,
        k_EVoiceResultBufferTooSmall = 4,
        k_EVoiceResultDataCorrupted = 5,
        k_EVoiceResultRestricted = 6,
        k_EVoiceResultUnsupportedCodec = 7,
        k_EVoiceResultReceiverOutOfDate = 8,
        k_EVoiceResultReceiverDidNotAnswer = 9
    }

    public enum EDenyReason
    {
        k_EDenyInvalid = 0,
        k_EDenyInvalidVersion = 1,
        k_EDenyGeneric = 2,
        k_EDenyNotLoggedOn = 3,
        k_EDenyNoLicense = 4,
        k_EDenyCheater = 5,
        k_EDenyLoggedInElseWhere = 6,
        k_EDenyUnknownText = 7,
        k_EDenyIncompatibleAnticheat = 8,
        k_EDenyMemoryCorruption = 9,
        k_EDenyIncompatibleSoftware = 10,
        k_EDenySteamConnectionLost = 11,
        k_EDenySteamConnectionError = 12,
        k_EDenySteamResponseTimedOut = 13,
        k_EDenySteamValidationStalled = 14,
        k_EDenySteamOwnerLeftGuestUser = 15
    }

    public enum EBeginAuthSessionResult
    {
        k_EBeginAuthSessionResultOK = 0,
        k_EBeginAuthSessionResultInvalidTicket = 1,
        k_EBeginAuthSessionResultDuplicateRequest = 2,
        k_EBeginAuthSessionResultInvalidVersion = 3,
        k_EBeginAuthSessionResultGameMismatch = 4,
        k_EBeginAuthSessionResultExpiredTicket = 5
    }

    public enum EAuthSessionResponse
    {
        k_EAuthSessionResponseOK = 0,
        k_EAuthSessionResponseUserNotConnectedToSteam = 1,
        k_EAuthSessionResponseNoLicenseOrExpired = 2,
        k_EAuthSessionResponseVACBanned = 3,
        k_EAuthSessionResponseLoggedInElseWhere = 4,
        k_EAuthSessionResponseVACCheckTimedOut = 5,
        k_EAuthSessionResponseAuthTicketCanceled = 6,
        k_EAuthSessionResponseAuthTicketInvalidAlreadyUsed = 7,
        k_EAuthSessionResponseAuthTicketInvalid = 8,
        k_EAuthSessionResponsePublisherIssuedBan = 9
    }

    public enum EUserHasLicenseForAppResult
    {
        k_EUserHasLicenseResultHasLicense = 0,
        k_EUserHasLicenseResultDoesNotHaveLicense = 1,
        k_EUserHasLicenseResultNoAuth = 2
    }

    public enum EAccountType
    {
        k_EAccountTypeInvalid = 0,
        k_EAccountTypeIndividual = 1,
        k_EAccountTypeMultiseat = 2,
        k_EAccountTypeGameServer = 3,
        k_EAccountTypeAnonGameServer = 4,
        k_EAccountTypePending = 5,
        k_EAccountTypeContentServer = 6,
        k_EAccountTypeClan = 7,
        k_EAccountTypeChat = 8,
        k_EAccountTypeConsoleUser = 9,
        k_EAccountTypeAnonUser = 10,
        k_EAccountTypeMax = 11
    }

    public enum EAppReleaseState
    {
        k_EAppReleaseState_Unknown = 0,
        k_EAppReleaseState_Unavailable = 1,
        k_EAppReleaseState_Prerelease = 2,
        k_EAppReleaseState_PreloadOnly = 3,
        k_EAppReleaseState_Released = 4
    }

    public enum EAppOwnershipFlags
    {
        k_EAppOwnershipFlags_None = 0,
        k_EAppOwnershipFlags_OwnsLicense = 1,
        k_EAppOwnershipFlags_FreeLicense = 2,
        k_EAppOwnershipFlags_RegionRestricted = 4,
        k_EAppOwnershipFlags_LowViolence = 8,
        k_EAppOwnershipFlags_InvalidPlatform = 16,
        k_EAppOwnershipFlags_SharedLicense = 32,
        k_EAppOwnershipFlags_FreeWeekend = 64,
        k_EAppOwnershipFlags_RetailLicense = 128,
        k_EAppOwnershipFlags_LicenseLocked = 256,
        k_EAppOwnershipFlags_LicensePending = 512,
        k_EAppOwnershipFlags_LicenseExpired = 1024,
        k_EAppOwnershipFlags_LicensePermanent = 2048,
        k_EAppOwnershipFlags_LicenseRecurring = 4096,
        k_EAppOwnershipFlags_LicenseCanceled = 8192,
        k_EAppOwnershipFlags_AutoGrant = 16384,
        k_EAppOwnershipFlags_PendingGift = 32768,
        k_EAppOwnershipFlags_RentalNotActivated = 65536,
        k_EAppOwnershipFlags_Rental = 131072
    }

    public enum EAppType
    {
        k_EAppType_Invalid = 0,
        k_EAppType_Game = 1,
        k_EAppType_Application = 2,
        k_EAppType_Tool = 4,
        k_EAppType_Demo = 8,
        k_EAppType_Media_DEPRECATED = 16,
        k_EAppType_DLC = 32,
        k_EAppType_Guide = 64,
        k_EAppType_Driver = 128,
        k_EAppType_Config = 256,
        k_EAppType_Hardware = 512,
        k_EAppType_Franchise = 1024,
        k_EAppType_Video = 2048,
        k_EAppType_Plugin = 4096,
        k_EAppType_Music = 8192,
        k_EAppType_Series = 16384,
        k_EAppType_Shortcut = 1073741824,
        k_EAppType_DepotOnly = -2147483648
    }

    public enum ESteamUserStatType
    {
        k_ESteamUserStatTypeINVALID = 0,
        k_ESteamUserStatTypeINT = 1,
        k_ESteamUserStatTypeFLOAT = 2,
        k_ESteamUserStatTypeAVGRATE = 3,
        k_ESteamUserStatTypeACHIEVEMENTS = 4,
        k_ESteamUserStatTypeGROUPACHIEVEMENTS = 5,
        k_ESteamUserStatTypeMAX = 6
    }

    public enum EChatEntryType
    {
        k_EChatEntryTypeInvalid = 0,
        k_EChatEntryTypeChatMsg = 1,
        k_EChatEntryTypeTyping = 2,
        k_EChatEntryTypeInviteGame = 3,
        k_EChatEntryTypeEmote = 4,
        k_EChatEntryTypeLeftConversation = 6,
        k_EChatEntryTypeEntered = 7,
        k_EChatEntryTypeWasKicked = 8,
        k_EChatEntryTypeWasBanned = 9,
        k_EChatEntryTypeDisconnected = 10,
        k_EChatEntryTypeHistoricalChat = 11,
        k_EChatEntryTypeLinkBlocked = 14
    }

    public enum EChatRoomEnterResponse
    {
        k_EChatRoomEnterResponseSuccess = 1,
        k_EChatRoomEnterResponseDoesntExist = 2,
        k_EChatRoomEnterResponseNotAllowed = 3,
        k_EChatRoomEnterResponseFull = 4,
        k_EChatRoomEnterResponseError = 5,
        k_EChatRoomEnterResponseBanned = 6,
        k_EChatRoomEnterResponseLimited = 7,
        k_EChatRoomEnterResponseClanDisabled = 8,
        k_EChatRoomEnterResponseCommunityBan = 9,
        k_EChatRoomEnterResponseMemberBlockedYou = 10,
        k_EChatRoomEnterResponseYouBlockedMember = 11
    }

    public enum EChatSteamIDInstanceFlags
    {
        k_EChatAccountInstanceMask = 4095,
        k_EChatInstanceFlagClan = 524288,
        k_EChatInstanceFlagLobby = 262144,
        k_EChatInstanceFlagMMSLobby = 131072
    }

    public enum EMarketingMessageFlags
    {
        k_EMarketingMessageFlagsNone = 0,
        k_EMarketingMessageFlagsHighPriority = 1,
        k_EMarketingMessageFlagsPlatformWindows = 2,
        k_EMarketingMessageFlagsPlatformMac = 4,
        k_EMarketingMessageFlagsPlatformLinux = 8,
        k_EMarketingMessageFlagsPlatformRestrictions = 14
    }

    public enum ENotificationPosition
    {
        k_EPositionTopLeft = 0,
        k_EPositionTopRight = 1,
        k_EPositionBottomLeft = 2,
        k_EPositionBottomRight = 3
    }

    public enum EBroadcastUploadResult
    {
        k_EBroadcastUploadResultNone = 0,
        k_EBroadcastUploadResultOK = 1,
        k_EBroadcastUploadResultInitFailed = 2,
        k_EBroadcastUploadResultFrameFailed = 3,
        k_EBroadcastUploadResultTimeout = 4,
        k_EBroadcastUploadResultBandwidthExceeded = 5,
        k_EBroadcastUploadResultLowFPS = 6,
        k_EBroadcastUploadResultMissingKeyFrames = 7,
        k_EBroadcastUploadResultNoConnection = 8,
        k_EBroadcastUploadResultRelayFailed = 9,
        k_EBroadcastUploadResultSettingsChanged = 10,
        k_EBroadcastUploadResultMissingAudio = 11,
        k_EBroadcastUploadResultTooFarBehind = 12,
        k_EBroadcastUploadResultTranscodeBehind = 13
    }

    public enum ELaunchOptionType
    {
        k_ELaunchOptionType_None = 0,
        k_ELaunchOptionType_Default = 1,
        k_ELaunchOptionType_SafeMode = 2,
        k_ELaunchOptionType_Multiplayer = 3,
        k_ELaunchOptionType_Config = 4,
        k_ELaunchOptionType_OpenVR = 5,
        k_ELaunchOptionType_Server = 6,
        k_ELaunchOptionType_Editor = 7,
        k_ELaunchOptionType_Manual = 8,
        k_ELaunchOptionType_Benchmark = 9,
        k_ELaunchOptionType_Option1 = 10,
        k_ELaunchOptionType_Option2 = 11,
        k_ELaunchOptionType_Option3 = 12,
        k_ELaunchOptionType_OculusVR = 13,
        k_ELaunchOptionType_OpenVROverlay = 14,
        k_ELaunchOptionType_OSVR = 15,
        k_ELaunchOptionType_Dialog = 1000
    }

    public enum EVRHMDType
    {
        k_eEVRHMDType_None = -1,
        k_eEVRHMDType_Unknown = 0,
        k_eEVRHMDType_HTC_Dev = 1,
        k_eEVRHMDType_HTC_VivePre = 2,
        k_eEVRHMDType_HTC_Vive = 3,
        k_eEVRHMDType_HTC_Unknown = 20,
        k_eEVRHMDType_Oculus_DK1 = 21,
        k_eEVRHMDType_Oculus_DK2 = 22,
        k_eEVRHMDType_Oculus_Rift = 23,
        k_eEVRHMDType_Oculus_Unknown = 40
    }

    public enum EControllerType
    {
        k_eControllerType_None = -1,
        k_eControllerType_Unknown = 0,
        k_eControllerType_UnknownSteamController = 1,
        k_eControllerType_SteamController = 2,
        k_eControllerType_UnknownNonSteamController = 30,
        k_eControllerType_XBox360Controller = 31,
        k_eControllerType_XBoxOneController = 32,
        k_eControllerType_PS3Controller = 33,
        k_eControllerType_PS4Controller = 34,
        k_eControllerType_WiiController = 35,
        k_eControllerType_AppleController = 36
    }

    public enum EFailureType
    {
        k_EFailureFlushedCallbackQueue = 0,
        k_EFailurePipeFail = 1
    }

    public enum EFriendRelationship
    {
        k_EFriendRelationshipNone = 0,
        k_EFriendRelationshipBlocked = 1,
        k_EFriendRelationshipRequestRecipient = 2,
        k_EFriendRelationshipFriend = 3,
        k_EFriendRelationshipRequestInitiator = 4,
        k_EFriendRelationshipIgnored = 5,
        k_EFriendRelationshipIgnoredFriend = 6,
        k_EFriendRelationshipSuggested_DEPRECATED = 7,
        k_EFriendRelationshipMax = 8
    }

    public enum EPersonaState
    {
        k_EPersonaStateOffline = 0,
        k_EPersonaStateOnline = 1,
        k_EPersonaStateBusy = 2,
        k_EPersonaStateAway = 3,
        k_EPersonaStateSnooze = 4,
        k_EPersonaStateLookingToTrade = 5,
        k_EPersonaStateLookingToPlay = 6,
        k_EPersonaStateMax = 7
    }

    public enum EFriendFlags
    {
        k_EFriendFlagNone = 0,
        k_EFriendFlagBlocked = 1,
        k_EFriendFlagFriendshipRequested = 2,
        k_EFriendFlagImmediate = 4,
        k_EFriendFlagClanMember = 8,
        k_EFriendFlagOnGameServer = 16,
        k_EFriendFlagRequestingFriendship = 128,
        k_EFriendFlagRequestingInfo = 256,
        k_EFriendFlagIgnored = 512,
        k_EFriendFlagIgnoredFriend = 1024,
        k_EFriendFlagSuggested = 2048,
        k_EFriendFlagChatMember = 4096,
        k_EFriendFlagAll = 65535
    }

    public enum EUserRestriction
    {
        k_nUserRestrictionNone = 0,
        k_nUserRestrictionUnknown = 1,
        k_nUserRestrictionAnyChat = 2,
        k_nUserRestrictionVoiceChat = 4,
        k_nUserRestrictionGroupChat = 8,
        k_nUserRestrictionRating = 16,
        k_nUserRestrictionGameInvites = 32,
        k_nUserRestrictionTrading = 64
    }

    public enum EOverlayToStoreFlag
    {
        k_EOverlayToStoreFlag_None = 0,
        k_EOverlayToStoreFlag_AddToCart = 1,
        k_EOverlayToStoreFlag_AddToCartAndShow = 2
    }

    public enum EPersonaChange
    {
        k_EPersonaChangeName = 1,
        k_EPersonaChangeStatus = 2,
        k_EPersonaChangeComeOnline = 4,
        k_EPersonaChangeGoneOffline = 8,
        k_EPersonaChangeGamePlayed = 16,
        k_EPersonaChangeGameServer = 32,
        k_EPersonaChangeAvatar = 64,
        k_EPersonaChangeJoinedSource = 128,
        k_EPersonaChangeLeftSource = 256,
        k_EPersonaChangeRelationshipChanged = 512,
        k_EPersonaChangeNameFirstSet = 1024,
        k_EPersonaChangeFacebookInfo = 2048,
        k_EPersonaChangeNickname = 4096,
        k_EPersonaChangeSteamLevel = 8192
    }

    public enum ESteamAPICallFailure
    {
        k_ESteamAPICallFailureNone = -1,
        k_ESteamAPICallFailureSteamGone = 0,
        k_ESteamAPICallFailureNetworkFailure = 1,
        k_ESteamAPICallFailureInvalidHandle = 2,
        k_ESteamAPICallFailureMismatchedCallback = 3
    }

    public enum EGamepadTextInputMode
    {
        k_EGamepadTextInputModeNormal = 0,
        k_EGamepadTextInputModePassword = 1
    }

    public enum EGamepadTextInputLineMode
    {
        k_EGamepadTextInputLineModeSingleLine = 0,
        k_EGamepadTextInputLineModeMultipleLines = 1
    }

    public enum ECheckFileSignature
    {
        k_ECheckFileSignatureInvalidSignature = 0,
        k_ECheckFileSignatureValidSignature = 1,
        k_ECheckFileSignatureFileNotFound = 2,
        k_ECheckFileSignatureNoSignaturesFoundForThisApp = 3,
        k_ECheckFileSignatureNoSignaturesFoundForThisFile = 4
    }

    public enum EMatchMakingServerResponse
    {
        eServerResponded = 0,
        eServerFailedToRespond = 1,
        eNoServersListedOnMasterServer = 2
    }

    public enum ELobbyType
    {
        k_ELobbyTypePrivate = 0,
        k_ELobbyTypeFriendsOnly = 1,
        k_ELobbyTypePublic = 2,
        k_ELobbyTypeInvisible = 3
    }

    public enum ELobbyComparison
    {
        k_ELobbyComparisonEqualToOrLessThan = -2,
        k_ELobbyComparisonLessThan = -1,
        k_ELobbyComparisonEqual = 0,
        k_ELobbyComparisonGreaterThan = 1,
        k_ELobbyComparisonEqualToOrGreaterThan = 2,
        k_ELobbyComparisonNotEqual = 3
    }

    public enum ELobbyDistanceFilter
    {
        k_ELobbyDistanceFilterClose = 0,
        k_ELobbyDistanceFilterDefault = 1,
        k_ELobbyDistanceFilterFar = 2,
        k_ELobbyDistanceFilterWorldwide = 3
    }

    public enum EChatMemberStateChange
    {
        k_EChatMemberStateChangeEntered = 1,
        k_EChatMemberStateChangeLeft = 2,
        k_EChatMemberStateChangeDisconnected = 4,
        k_EChatMemberStateChangeKicked = 8,
        k_EChatMemberStateChangeBanned = 16
    }

    public enum ERemoteStoragePlatform
    {
        k_ERemoteStoragePlatformNone = 0,
        k_ERemoteStoragePlatformWindows = 1,
        k_ERemoteStoragePlatformOSX = 2,
        k_ERemoteStoragePlatformPS3 = 4,
        k_ERemoteStoragePlatformLinux = 8,
        k_ERemoteStoragePlatformReserved2 = 16,
        k_ERemoteStoragePlatformAll = -1
    }

    public enum ERemoteStoragePublishedFileVisibility
    {
        k_ERemoteStoragePublishedFileVisibilityPublic = 0,
        k_ERemoteStoragePublishedFileVisibilityFriendsOnly = 1,
        k_ERemoteStoragePublishedFileVisibilityPrivate = 2
    }

    public enum EWorkshopFileType
    {
        k_EWorkshopFileTypeFirst = 0,
        k_EWorkshopFileTypeCommunity = 0,
        k_EWorkshopFileTypeMicrotransaction = 1,
        k_EWorkshopFileTypeCollection = 2,
        k_EWorkshopFileTypeArt = 3,
        k_EWorkshopFileTypeVideo = 4,
        k_EWorkshopFileTypeScreenshot = 5,
        k_EWorkshopFileTypeGame = 6,
        k_EWorkshopFileTypeSoftware = 7,
        k_EWorkshopFileTypeConcept = 8,
        k_EWorkshopFileTypeWebGuide = 9,
        k_EWorkshopFileTypeIntegratedGuide = 10,
        k_EWorkshopFileTypeMerch = 11,
        k_EWorkshopFileTypeControllerBinding = 12,
        k_EWorkshopFileTypeSteamworksAccessInvite = 13,
        k_EWorkshopFileTypeSteamVideo = 14,
        k_EWorkshopFileTypeGameManagedItem = 15,
        k_EWorkshopFileTypeMax = 16
    }

    public enum EWorkshopVote
    {
        k_EWorkshopVoteUnvoted = 0,
        k_EWorkshopVoteFor = 1,
        k_EWorkshopVoteAgainst = 2,
        k_EWorkshopVoteLater = 3
    }

    public enum EWorkshopFileAction
    {
        k_EWorkshopFileActionPlayed = 0,
        k_EWorkshopFileActionCompleted = 1
    }

    public enum EWorkshopEnumerationType
    {
        k_EWorkshopEnumerationTypeRankedByVote = 0,
        k_EWorkshopEnumerationTypeRecent = 1,
        k_EWorkshopEnumerationTypeTrending = 2,
        k_EWorkshopEnumerationTypeFavoritesOfFriends = 3,
        k_EWorkshopEnumerationTypeVotedByFriends = 4,
        k_EWorkshopEnumerationTypeContentByFriends = 5,
        k_EWorkshopEnumerationTypeRecentFromFollowedUsers = 6
    }

    public enum EWorkshopVideoProvider
    {
        k_EWorkshopVideoProviderNone = 0,
        k_EWorkshopVideoProviderYoutube = 1
    }

    public enum EUGCReadAction
    {
        k_EUGCRead_ContinueReadingUntilFinished = 0,
        k_EUGCRead_ContinueReading = 1,
        k_EUGCRead_Close = 2
    }

    public enum ELeaderboardDataRequest
    {
        k_ELeaderboardDataRequestGlobal = 0,
        k_ELeaderboardDataRequestGlobalAroundUser = 1,
        k_ELeaderboardDataRequestFriends = 2,
        k_ELeaderboardDataRequestUsers = 3
    }

    public enum ELeaderboardSortMethod
    {
        k_ELeaderboardSortMethodNone = 0,
        k_ELeaderboardSortMethodAscending = 1,
        k_ELeaderboardSortMethodDescending = 2
    }

    public enum ELeaderboardDisplayType
    {
        k_ELeaderboardDisplayTypeNone = 0,
        k_ELeaderboardDisplayTypeNumeric = 1,
        k_ELeaderboardDisplayTypeTimeSeconds = 2,
        k_ELeaderboardDisplayTypeTimeMilliSeconds = 3
    }

    public enum ELeaderboardUploadScoreMethod
    {
        k_ELeaderboardUploadScoreMethodNone = 0,
        k_ELeaderboardUploadScoreMethodKeepBest = 1,
        k_ELeaderboardUploadScoreMethodForceUpdate = 2
    }

    public enum ERegisterActivationCodeResult
    {
        k_ERegisterActivationCodeResultOK = 0,
        k_ERegisterActivationCodeResultFail = 1,
        k_ERegisterActivationCodeResultAlreadyRegistered = 2,
        k_ERegisterActivationCodeResultTimeout = 3,
        k_ERegisterActivationCodeAlreadyOwned = 4
    }

    public enum EP2PSessionError
    {
        k_EP2PSessionErrorNone = 0,
        k_EP2PSessionErrorNotRunningApp = 1,
        k_EP2PSessionErrorNoRightsToApp = 2,
        k_EP2PSessionErrorDestinationNotLoggedIn = 3,
        k_EP2PSessionErrorTimeout = 4,
        k_EP2PSessionErrorMax = 5
    }

    public enum EP2PSend
    {
        k_EP2PSendUnreliable = 0,
        k_EP2PSendUnreliableNoDelay = 1,
        k_EP2PSendReliable = 2,
        k_EP2PSendReliableWithBuffering = 3
    }

    public enum ESNetSocketState
    {
        k_ESNetSocketStateInvalid = 0,
        k_ESNetSocketStateConnected = 1,
        k_ESNetSocketStateInitiated = 10,
        k_ESNetSocketStateLocalCandidatesFound = 11,
        k_ESNetSocketStateReceivedRemoteCandidates = 12,
        k_ESNetSocketStateChallengeHandshake = 15,
        k_ESNetSocketStateDisconnecting = 21,
        k_ESNetSocketStateLocalDisconnect = 22,
        k_ESNetSocketStateTimeoutDuringConnect = 23,
        k_ESNetSocketStateRemoteEndDisconnected = 24,
        k_ESNetSocketStateConnectionBroken = 25
    }

    public enum ESNetSocketConnectionType
    {
        k_ESNetSocketConnectionTypeNotConnected = 0,
        k_ESNetSocketConnectionTypeUDP = 1,
        k_ESNetSocketConnectionTypeUDPRelay = 2
    }

    public enum EVRScreenshotType
    {
        k_EVRScreenshotType_None = 0,
        k_EVRScreenshotType_Mono = 1,
        k_EVRScreenshotType_Stereo = 2,
        k_EVRScreenshotType_MonoCubemap = 3,
        k_EVRScreenshotType_MonoPanorama = 4,
        k_EVRScreenshotType_StereoPanorama = 5
    }

    public enum AudioPlayback_Status
    {
        AudioPlayback_Undefined = 0,
        AudioPlayback_Playing = 1,
        AudioPlayback_Paused = 2,
        AudioPlayback_Idle = 3
    }

    public enum EHTTPMethod
    {
        k_EHTTPMethodInvalid = 0,
        k_EHTTPMethodGET = 1,
        k_EHTTPMethodHEAD = 2,
        k_EHTTPMethodPOST = 3,
        k_EHTTPMethodPUT = 4,
        k_EHTTPMethodDELETE = 5,
        k_EHTTPMethodOPTIONS = 6,
        k_EHTTPMethodPATCH = 7
    }

    public enum EHTTPStatusCode
    {
        k_EHTTPStatusCodeInvalid = 0,
        k_EHTTPStatusCode100Continue = 100,
        k_EHTTPStatusCode101SwitchingProtocols = 101,
        k_EHTTPStatusCode200OK = 200,
        k_EHTTPStatusCode201Created = 201,
        k_EHTTPStatusCode202Accepted = 202,
        k_EHTTPStatusCode203NonAuthoritative = 203,
        k_EHTTPStatusCode204NoContent = 204,
        k_EHTTPStatusCode205ResetContent = 205,
        k_EHTTPStatusCode206PartialContent = 206,
        k_EHTTPStatusCode300MultipleChoices = 300,
        k_EHTTPStatusCode301MovedPermanently = 301,
        k_EHTTPStatusCode302Found = 302,
        k_EHTTPStatusCode303SeeOther = 303,
        k_EHTTPStatusCode304NotModified = 304,
        k_EHTTPStatusCode305UseProxy = 305,
        k_EHTTPStatusCode307TemporaryRedirect = 307,
        k_EHTTPStatusCode400BadRequest = 400,
        k_EHTTPStatusCode401Unauthorized = 401,
        k_EHTTPStatusCode402PaymentRequired = 402,
        k_EHTTPStatusCode403Forbidden = 403,
        k_EHTTPStatusCode404NotFound = 404,
        k_EHTTPStatusCode405MethodNotAllowed = 405,
        k_EHTTPStatusCode406NotAcceptable = 406,
        k_EHTTPStatusCode407ProxyAuthRequired = 407,
        k_EHTTPStatusCode408RequestTimeout = 408,
        k_EHTTPStatusCode409Conflict = 409,
        k_EHTTPStatusCode410Gone = 410,
        k_EHTTPStatusCode411LengthRequired = 411,
        k_EHTTPStatusCode412PreconditionFailed = 412,
        k_EHTTPStatusCode413RequestEntityTooLarge = 413,
        k_EHTTPStatusCode414RequestURITooLong = 414,
        k_EHTTPStatusCode415UnsupportedMediaType = 415,
        k_EHTTPStatusCode416RequestedRangeNotSatisfiable = 416,
        k_EHTTPStatusCode417ExpectationFailed = 417,
        k_EHTTPStatusCode4xxUnknown = 418,
        k_EHTTPStatusCode429TooManyRequests = 429,
        k_EHTTPStatusCode500InternalServerError = 500,
        k_EHTTPStatusCode501NotImplemented = 501,
        k_EHTTPStatusCode502BadGateway = 502,
        k_EHTTPStatusCode503ServiceUnavailable = 503,
        k_EHTTPStatusCode504GatewayTimeout = 504,
        k_EHTTPStatusCode505HTTPVersionNotSupported = 505,
        k_EHTTPStatusCode5xxUnknown = 599
    }

    public enum ESteamControllerPad
    {
        k_ESteamControllerPad_Left = 0,
        k_ESteamControllerPad_Right = 1
    }

    public enum EControllerSource
    {
        k_EControllerSource_None = 0,
        k_EControllerSource_LeftTrackpad = 1,
        k_EControllerSource_RightTrackpad = 2,
        k_EControllerSource_Joystick = 3,
        k_EControllerSource_ABXY = 4,
        k_EControllerSource_Switch = 5,
        k_EControllerSource_LeftTrigger = 6,
        k_EControllerSource_RightTrigger = 7,
        k_EControllerSource_Gyro = 8,
        k_EControllerSource_Count = 9
    }

    public enum EControllerSourceMode
    {
        k_EControllerSourceMode_None = 0,
        k_EControllerSourceMode_Dpad = 1,
        k_EControllerSourceMode_Buttons = 2,
        k_EControllerSourceMode_FourButtons = 3,
        k_EControllerSourceMode_AbsoluteMouse = 4,
        k_EControllerSourceMode_RelativeMouse = 5,
        k_EControllerSourceMode_JoystickMove = 6,
        k_EControllerSourceMode_JoystickCamera = 7,
        k_EControllerSourceMode_ScrollWheel = 8,
        k_EControllerSourceMode_Trigger = 9,
        k_EControllerSourceMode_TouchMenu = 10,
        k_EControllerSourceMode_MouseJoystick = 11,
        k_EControllerSourceMode_MouseRegion = 12,
        k_EControllerSourceMode_RadialMenu = 13,
        k_EControllerSourceMode_Switches = 14
    }

    public enum EControllerActionOrigin
    {
        k_EControllerActionOrigin_None = 0,
        k_EControllerActionOrigin_A = 1,
        k_EControllerActionOrigin_B = 2,
        k_EControllerActionOrigin_X = 3,
        k_EControllerActionOrigin_Y = 4,
        k_EControllerActionOrigin_LeftBumper = 5,
        k_EControllerActionOrigin_RightBumper = 6,
        k_EControllerActionOrigin_LeftGrip = 7,
        k_EControllerActionOrigin_RightGrip = 8,
        k_EControllerActionOrigin_Start = 9,
        k_EControllerActionOrigin_Back = 10,
        k_EControllerActionOrigin_LeftPad_Touch = 11,
        k_EControllerActionOrigin_LeftPad_Swipe = 12,
        k_EControllerActionOrigin_LeftPad_Click = 13,
        k_EControllerActionOrigin_LeftPad_DPadNorth = 14,
        k_EControllerActionOrigin_LeftPad_DPadSouth = 15,
        k_EControllerActionOrigin_LeftPad_DPadWest = 16,
        k_EControllerActionOrigin_LeftPad_DPadEast = 17,
        k_EControllerActionOrigin_RightPad_Touch = 18,
        k_EControllerActionOrigin_RightPad_Swipe = 19,
        k_EControllerActionOrigin_RightPad_Click = 20,
        k_EControllerActionOrigin_RightPad_DPadNorth = 21,
        k_EControllerActionOrigin_RightPad_DPadSouth = 22,
        k_EControllerActionOrigin_RightPad_DPadWest = 23,
        k_EControllerActionOrigin_RightPad_DPadEast = 24,
        k_EControllerActionOrigin_LeftTrigger_Pull = 25,
        k_EControllerActionOrigin_LeftTrigger_Click = 26,
        k_EControllerActionOrigin_RightTrigger_Pull = 27,
        k_EControllerActionOrigin_RightTrigger_Click = 28,
        k_EControllerActionOrigin_LeftStick_Move = 29,
        k_EControllerActionOrigin_LeftStick_Click = 30,
        k_EControllerActionOrigin_LeftStick_DPadNorth = 31,
        k_EControllerActionOrigin_LeftStick_DPadSouth = 32,
        k_EControllerActionOrigin_LeftStick_DPadWest = 33,
        k_EControllerActionOrigin_LeftStick_DPadEast = 34,
        k_EControllerActionOrigin_Gyro_Move = 35,
        k_EControllerActionOrigin_Gyro_Pitch = 36,
        k_EControllerActionOrigin_Gyro_Yaw = 37,
        k_EControllerActionOrigin_Gyro_Roll = 38,
        k_EControllerActionOrigin_Count = 39
    }

    public enum EControllerActivationType
    {
        k_EControllerActivationType_None = 0,
        k_EControllerActivationType_FullPress = 1,
        k_EControllerActivationType_SoftPress = 2,
        k_EControllerActivationType_StartPress = 3,
        k_EControllerActivationType_Release = 4,
        k_EControllerActivationType_LongPress = 5,
        k_EControllerActivationType_DoublePress = 6,
        k_EControllerActivationType_Analog = 7
    }

    public enum EControllerPressureButton
    {
        k_EControllerPressureButton_LeftTrackPad = 0,
        k_EControllerPressureButton_RightTrackPad = 1,
        k_EControllerPressureButton_LeftBumper = 2,
        k_EControllerPressureButton_RightBumper = 3,
        k_EControllerPressureButton_LeftGripLower = 4,
        k_EControllerPressureButton_RightGripLower = 5,
        k_EControllerPressureButton_LeftGripUpper = 6,
        k_EControllerPressureButton_RightGripUpper = 7,
        k_EControllerPressureButton_Invalid = 8
    }

    public enum EControllerActivatorOutputAxis
    {
        k_EOutputAxisLeftTrigger = 0,
        k_EOutputAxisRightTrigger = 1,
        k_EOutputAxisLeftThumbXPos = 2,
        k_EOutputAxisLeftThumbXNeg = 3,
        k_EOutputAxisLeftThumbYPos = 4,
        k_EOutputAxisLeftThumbYNeg = 5,
        k_EOutputAxisRightThumbXPos = 6,
        k_EOutputAxisRightThumbXNeg = 7,
        k_EOutputAxisRightThumbYPos = 8,
        k_EOutputAxisRightThumbYNeg = 9
    }

    public enum EControllerConfigFeature
    {
        k_EControllerConfigFeature_None = 0,
        k_EControllerConfigFeature_Gamepad = 1,
        k_EControllerConfigFeature_Keyboard = 2,
        k_EControllerConfigFeature_Mouse = 3,
        k_EControllerConfigFeature_Gyro = 4,
        k_EControllerConfigFeature_TouchMenu = 5,
        k_EControllerConfigFeature_ModeShift = 6,
        k_EControllerConfigFeature_ActionSet = 7,
        k_EControllerConfigFeature_Activator = 8
    }

    public enum EControllerPopupMenuActivationType
    {
        k_EMenuButtonPress = 0,
        k_EMenuButtonRelease = 1,
        k_EMenuTouchRelease = 2,
        k_EMenuTouchAlways = 3
    }

    public enum EUGCMatchingUGCType
    {
        k_EUGCMatchingUGCType_Items = 0,
        k_EUGCMatchingUGCType_Items_Mtx = 1,
        k_EUGCMatchingUGCType_Items_ReadyToUse = 2,
        k_EUGCMatchingUGCType_Collections = 3,
        k_EUGCMatchingUGCType_Artwork = 4,
        k_EUGCMatchingUGCType_Videos = 5,
        k_EUGCMatchingUGCType_Screenshots = 6,
        k_EUGCMatchingUGCType_AllGuides = 7,
        k_EUGCMatchingUGCType_WebGuides = 8,
        k_EUGCMatchingUGCType_IntegratedGuides = 9,
        k_EUGCMatchingUGCType_UsableInGame = 10,
        k_EUGCMatchingUGCType_ControllerBindings = 11,
        k_EUGCMatchingUGCType_GameManagedItems = 12,
        k_EUGCMatchingUGCType_All = -1
    }

    public enum EUserUGCList
    {
        k_EUserUGCList_Published = 0,
        k_EUserUGCList_VotedOn = 1,
        k_EUserUGCList_VotedUp = 2,
        k_EUserUGCList_VotedDown = 3,
        k_EUserUGCList_WillVoteLater = 4,
        k_EUserUGCList_Favorited = 5,
        k_EUserUGCList_Subscribed = 6,
        k_EUserUGCList_UsedOrPlayed = 7,
        k_EUserUGCList_Followed = 8
    }

    public enum EUserUGCListSortOrder
    {
        k_EUserUGCListSortOrder_CreationOrderDesc = 0,
        k_EUserUGCListSortOrder_CreationOrderAsc = 1,
        k_EUserUGCListSortOrder_TitleAsc = 2,
        k_EUserUGCListSortOrder_LastUpdatedDesc = 3,
        k_EUserUGCListSortOrder_SubscriptionDateDesc = 4,
        k_EUserUGCListSortOrder_VoteScoreDesc = 5,
        k_EUserUGCListSortOrder_ForModeration = 6
    }

    public enum EUGCQuery
    {
        k_EUGCQuery_RankedByVote = 0,
        k_EUGCQuery_RankedByPublicationDate = 1,
        k_EUGCQuery_AcceptedForGameRankedByAcceptanceDate = 2,
        k_EUGCQuery_RankedByTrend = 3,
        k_EUGCQuery_FavoritedByFriendsRankedByPublicationDate = 4,
        k_EUGCQuery_CreatedByFriendsRankedByPublicationDate = 5,
        k_EUGCQuery_RankedByNumTimesReported = 6,
        k_EUGCQuery_CreatedByFollowedUsersRankedByPublicationDate = 7,
        k_EUGCQuery_NotYetRated = 8,
        k_EUGCQuery_RankedByTotalVotesAsc = 9,
        k_EUGCQuery_RankedByVotesUp = 10,
        k_EUGCQuery_RankedByTextSearch = 11,
        k_EUGCQuery_RankedByTotalUniqueSubscriptions = 12,
        k_EUGCQuery_RankedByPlaytimeTrend = 13,
        k_EUGCQuery_RankedByTotalPlaytime = 14,
        k_EUGCQuery_RankedByAveragePlaytimeTrend = 15,
        k_EUGCQuery_RankedByLifetimeAveragePlaytime = 16,
        k_EUGCQuery_RankedByPlaytimeSessionsTrend = 17,
        k_EUGCQuery_RankedByLifetimePlaytimeSessions = 18
    }

    public enum EItemUpdateStatus
    {
        k_EItemUpdateStatusInvalid = 0,
        k_EItemUpdateStatusPreparingConfig = 1,
        k_EItemUpdateStatusPreparingContent = 2,
        k_EItemUpdateStatusUploadingContent = 3,
        k_EItemUpdateStatusUploadingPreviewFile = 4,
        k_EItemUpdateStatusCommittingChanges = 5
    }

    public enum EItemState
    {
        k_EItemStateNone = 0,
        k_EItemStateSubscribed = 1,
        k_EItemStateLegacyItem = 2,
        k_EItemStateInstalled = 4,
        k_EItemStateNeedsUpdate = 8,
        k_EItemStateDownloading = 16,
        k_EItemStateDownloadPending = 32
    }

    public enum EItemStatistic
    {
        k_EItemStatistic_NumSubscriptions = 0,
        k_EItemStatistic_NumFavorites = 1,
        k_EItemStatistic_NumFollowers = 2,
        k_EItemStatistic_NumUniqueSubscriptions = 3,
        k_EItemStatistic_NumUniqueFavorites = 4,
        k_EItemStatistic_NumUniqueFollowers = 5,
        k_EItemStatistic_NumUniqueWebsiteViews = 6,
        k_EItemStatistic_ReportScore = 7,
        k_EItemStatistic_NumSecondsPlayed = 8,
        k_EItemStatistic_NumPlaytimeSessions = 9,
        k_EItemStatistic_NumComments = 10
    }

    public enum EItemPreviewType
    {
        k_EItemPreviewType_Image = 0,
        k_EItemPreviewType_YouTubeVideo = 1,
        k_EItemPreviewType_Sketchfab = 2,
        k_EItemPreviewType_EnvironmentMap_HorizontalCross = 3,
        k_EItemPreviewType_EnvironmentMap_LatLong = 4,
        k_EItemPreviewType_ReservedMax = 255
    }

    public enum EHTMLMouseButton
    {
        eHTMLMouseButton_Left = 0,
        eHTMLMouseButton_Right = 1,
        eHTMLMouseButton_Middle = 2
    }

    public enum EMouseCursor
    {
        dc_user = 0,
        dc_none = 1,
        dc_arrow = 2,
        dc_ibeam = 3,
        dc_hourglass = 4,
        dc_waitarrow = 5,
        dc_crosshair = 6,
        dc_up = 7,
        dc_sizenw = 8,
        dc_sizese = 9,
        dc_sizene = 10,
        dc_sizesw = 11,
        dc_sizew = 12,
        dc_sizee = 13,
        dc_sizen = 14,
        dc_sizes = 15,
        dc_sizewe = 16,
        dc_sizens = 17,
        dc_sizeall = 18,
        dc_no = 19,
        dc_hand = 20,
        dc_blank = 21,
        dc_middle_pan = 22,
        dc_north_pan = 23,
        dc_north_east_pan = 24,
        dc_east_pan = 25,
        dc_south_east_pan = 26,
        dc_south_pan = 27,
        dc_south_west_pan = 28,
        dc_west_pan = 29,
        dc_north_west_pan = 30,
        dc_alias = 31,
        dc_cell = 32,
        dc_colresize = 33,
        dc_copycur = 34,
        dc_verticaltext = 35,
        dc_rowresize = 36,
        dc_zoomin = 37,
        dc_zoomout = 38,
        dc_help = 39,
        dc_custom = 40,
        dc_last = 41
    }

    public enum EHTMLKeyModifiers
    {
        k_eHTMLKeyModifier_None = 0,
        k_eHTMLKeyModifier_AltDown = 1,
        k_eHTMLKeyModifier_CtrlDown = 2,
        k_eHTMLKeyModifier_ShiftDown = 4
    }

    public enum ESteamItemFlags
    {
        k_ESteamItemNoTrade = 1,
        k_ESteamItemRemoved = 256,
        k_ESteamItemConsumed = 512
    }
}