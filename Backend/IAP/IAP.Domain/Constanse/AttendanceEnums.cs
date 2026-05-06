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
        HalfDay
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