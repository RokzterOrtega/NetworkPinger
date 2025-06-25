Public Class Device
    Public Property Id As Integer
    Public Property IpAddress As String
    Public Property Description As String

    Public Overrides Function ToString() As String
        Return $"{Description} ({IpAddress})"
    End Function
End Class
