﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Constants
{
    public static class ResultMessages
    {
        #region Asset

        public static string AssetNotFount = "Asset is not found";
        public static string AddSuccessAssetMessage = "Asset is add operation succeeded";
        public static string AddErrorAssetMessage = "Asset is add operation failed";

        public static string UpdateSuccessAssetMessage = "Asset is update operatiion succeeded";
        public static string UpdateErrorAssetMessage = "Asset is update operation failed";
        public static string UpdateSaveFailedAssetMessage = "Asset is not saved";

        public static string DeleteSuccessAssetMessage = "Asset is delete operatiion succeeded";
        public static string DeleteErrorAssetMessage = "Asset is delete operation failed";

        public static string GetSuccessAssetMessage = "Asset is getting operation secceeded";
        public static string GetErrorAssetMessage = "Asset is getting operation failed";

        public static string GetAllSuccessAssetMessage = "Asset is getting all operation secceeded";
        public static string GetAllErrorAssetMessage = "Asset is getting all operation failed";

        #endregion

        #region AssetType
        
        public static string AssetTypeNotFound = "Asset type ise not found";
        public static string AddSuccessAssetTypeMessage = "Asset Type is add operation succeeded";
        public static string AddErrorAssetTypeMessage = "Asset Type is add operation failed";

        public static string DeleteSuccessAssetTypeMessage = "Asset Type is delete operation succeeded";
        public static string DeleteErrorAssetTypeMessage = "Asset Type is delete operation failed";

        public static string UpdateSuccessAssetTypeMessage = "Asset Type is update operatiion succeeded";
        public static string UpdateErrorAssetTypeMessage = "Asset Type is update operation failed";
        public static string UpdateSaveFailedAssetTypeMessage = "Asset Type is not saved";

        public static string GetSuccessAssetTypeMessage = "Asset is getting operation secceeded";
        public static string GetErrorAssetTypeMessage = "Asset is getting operation failed";

        public static string GetAllSuccessAssetTypeMessage = "Asset is getting all operation secceeded";
        public static string GetAllErrorAssetTypeMessage = "Asset is getting all operation failed";

        #endregion

        #region ServiceDatabase

        public static string ServiceDatabaseNotFound = "App is not found";
        public static string AddSuccessServiceDatabaseMessage = "Service Database is add operation succeeded";
        public static string AddErrorServiceDatabaseMessage = "Service Database is add operation failed";

        public static string DeleteSuccessServiceDatabaseMessage = "Service Database is delete operation succeeded";
        public static string DeleteErrorServiceDatabaseMessage = "Service Database is delete operation failed";

        public static string UpdateSuccessServiceDatabaseMessage = "Service Database is update operatiion succeeded";
        public static string UpdateErrorServiceDatabaseMessage = "Service Database is update operation failed";
        public static string UpdateSaveFailedServiceDatabaseMessage = "Service Database is not saved";

        public static string GetSuccessServiceDatabaseMessage = "Service Database is getting operation secceeded";
        public static string GetErrorServiceDatabaseMessage = "Service Database is getting operation failed";
        public static string GetAllSuccessServiceDatabaseMessage = "Service Database is getting all operation secceeded";
        public static string GetAllErrorServiceDatabaseMessage = "Service Database is getting all operation failed";

        #endregion

        #region Transfer

        public static string GetSuccessTransferMessage = "Transfer is getting operation secceeded";
        public static string GetErrorTransferMessage = "Transfer is getting operation failed";
        public static string GetAllSuccessTransferMessage = "Transfer is getting all operation secceeded";
        public static string GetAllErrorTransferMessage = "Transfer is getting all operation failed";

        #endregion


    }
}