namespace IAP.Domain.Entity
{
    public enum CheckStatus
    {
        NotChecked,
        CheckedIn,
        CheckedOut
    }

    public enum AttendanceStatus
    {
        Present,
        Absent,
        HalfDay,
        Permission
    }

    public enum DeviceStatus
    {
        Same,
        Changed,
        New
    }

    public enum GpsStatus
    {
        Inside,
        Outside
    }
}