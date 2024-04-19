using Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Domain.Validation
{
    public struct InvariantConstants
    {
        #region Event
        public const int Event_Tags_Limit = 5;
        #endregion

        #region EventTag
        public const int EventTag_Name_MaxLength = 10;
        public const int EventTag_Description_MaxLength = 10;
        #endregion

        #region EventManager
        public const PermissionsEnum EventManager_ManagerId_RequiredPermissions = PermissionsEnum.ManageEvents;
        public const int EventManager_Logbook_MaxLength = 1000;

        #endregion
    }
}
