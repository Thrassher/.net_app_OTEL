<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs"
    Inherits="DotNetOtelQA.DefaultPage" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>.NET OTel QA Application</title>
</head>
<body>
    <h1>.NET Framework OpenTelemetry QA App</h1>
    <p>Application is running.</p>
    <p><a href="/?action=health">Health check</a></p>
    <p><a href="/?action=error">Generate error</a></p>
    <p><a href="/?action=slow">Generate slow request</a></p>
</body>
</html>
