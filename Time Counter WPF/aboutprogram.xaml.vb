Imports System.Windows.Threading
Imports System.Drawing
Imports System.Windows.Forms.Control
Imports Microsoft.Win32

Public Class aboutprogram

    Public timer1 As New DispatcherTimer()
    Private dragging As Boolean
    Private pointClicked As Point
    Public mainfrm As New MainWindow
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        aboutprgfrm.Close()

    End Sub

    Private Sub Label_MouseMove(sender As Object, e As MouseEventArgs)


    End Sub

    Private Sub aboutprgfrm_Closed(sender As Object, e As EventArgs) Handles aboutprgfrm.Closed
        mainfrm.IsEnabled = True
        timer1.Stop()
    End Sub

    Private Sub aboutprgfrm_Loaded(sender As Object, e As RoutedEventArgs) Handles aboutprgfrm.Loaded
        Dim currentUserKey As RegistryKey = Registry.CurrentUser
        Dim dmitpctckey As RegistryKey = currentUserKey.CreateSubKey("Software\\DMITComp\\Time Counter")
        Dim languagesetgs As String = dmitpctckey.GetValue("Language").ToString()
        Dim Version As String = "2.0.0 RC2 (Jule 9, 2020)"
        If languagesetgs = "ru" Then
            aboutdlgtitle.Content = "О программе " + Chr(2) + "Счетчик времени DMITComp" + Chr(2)
            programname.Content = "Счетчик времени DMIT Computers"
            programversion.Content = "Версия " + Version
            copyrightlabel.Content = "© 2019-2020 DMIT Computers. Все права защищены."
            description.Text = "Проект Time Counter (Счетчик времени) создан на основе проекта Year Progress, разрабытваемого Филлипом Грасеком в 2015 г. Программа " + Chr(2) + "Счетчик времени" + Chr(2) + " представляет собой индикатор, который начинается от начала текущего года (01.01) и заканчивается концом текущего года (31.12), и число прошедших дней/процентов с начала текущего года. " + Chr(2) + "Счетчик времени" + Chr(2) + " портирован на нескольких языках программирования, включая Java, JavaScript, Delphi (Pascal) и Visual Basic."
        End If
        If languagesetgs = "en" Then
            aboutdlgtitle.Content = "About DMITComp Time Counter"
            programname.Content = "DMIT Computers Time Counter"
            programversion.Content = "Version " + Version
            copyrightlabel.Content = "© 2019-2020 DMIT Computers. All rights reversed."
            description.Text = "The 'Time Counter' project by DMIT Computers was created based on the Year Progress project, developed by Phillip Hracek in 2015. The Time Counter program is an progressbar that starts from the beginning of the current year (01.01) and ends with the end of the current year (31.12), and the number past days/percent since the beginning of the current year. 'Time Counter' has been ported to several programming languages, including Java, JavaScript, Delphi (Pascal), and Visual Basic."
        End If
        If languagesetgs = "ua" Then
            aboutdlgtitle.Content = "Про програму " + Chr(2) + "Лiчильник часу DMITComp" + Chr(2)
            programname.Content = "Лiчильник часу DMIT Computers"
            programversion.Content = "Версiя " + Version
            copyrightlabel.Content = "© 2019-2020 DMIT Computers. Всi права захищенi."
            description.Text = "Проект Time Counter (Лічильник часу) створений на основі проекту Year Progress, що розробляється Філіпом Грасеком в 2015-му.  Програма " + Chr(2) + "Лічильник часу" + Chr(2) + " є прогрессбар, який починається з початку поточного року (01.01) і закінчується кінцем поточного року (31.12), і число минулих днів/відсотків з початку поточного року. " + Chr(2) + "Лічильник часу" + Chr(2) + "портовано на декількох мовах програмування, включаючи Java, JavaScript, Delphi (Pascal) та Visual Basic."
        End If
        If languagesetgs = "de" Then
            aboutprgfrm.aboutdlgtitle.Content = "Über das Programm " + Chr(2) + "DMITComp Zeitzähler" + Chr(2)
            aboutprgfrm.programname.Content = "DMIT Computers Zeitzähler"
            aboutprgfrm.programversion.Content = "Ausführung " + Version
            aboutprgfrm.copyrightlabel.Content = "© 2019-2020 DMIT Computers. Alle Rechte vorbehalten."
            description.Text = "Die Beschreibung ist derzeit in drei Sprachen verfügbar."
        End If

        Timer1Start()
    End Sub

    Private Sub Timer1Start()
        timer1.Interval = New TimeSpan(0, 0, 0, 0, 50)
        AddHandler timer1.Tick, AddressOf Me.Timer1Tick
        timer1.Start()
    End Sub

    Private Sub Timer1Tick(sender As Object, e As EventArgs)
        Dim currentUserKey As RegistryKey = Registry.CurrentUser
        Dim dmitpctckey As RegistryKey = currentUserKey.CreateSubKey("Software\\DMITComp\\Time Counter")
        Dim languagesetgs As String = dmitpctckey.GetValue("Language").ToString()
        Dim Version As String = "2.0.0 RC2 (Jule 9, 2020)"
        If languagesetgs = "ru" Then
            aboutdlgtitle.Content = "О программе " + Chr(2) + "Счетчик времени DMITComp" + Chr(2)
            programname.Content = "Счетчик времени DMIT Computers"
            programversion.Content = "Версия " + Version
            copyrightlabel.Content = "© 2019-2020 DMIT Computers. Все права защищены."
            description.Text = "Проект Time Counter (Счетчик времени) создан на основе проекта Year Progress, разрабытваемого Филлипом Грасеком в 2015 г. Программа " + Chr(2) + "Счетчик времени" + Chr(2) + " представляет собой индикатор, который начинается от начала текущего года (01.01) и заканчивается концом текущего года (31.12), и число прошедших дней/процентов с начала текущего года. " + Chr(2) + "Счетчик времени" + Chr(2) + " портирован на нескольких языках программирования, включая Java, JavaScript, Delphi (Pascal) и Visual Basic."
        End If
        If languagesetgs = "en" Then
            aboutdlgtitle.Content = "About DMITComp Time Counter"
            programname.Content = "DMIT Computers Time Counter"
            programversion.Content = "Version " + Version
            copyrightlabel.Content = "© 2019-2020 DMIT Computers. All rights reversed."
            description.Text = "The 'Time Counter' project by DMIT Computers was created based on the Year Progress project, developed by Phillip Hracek in 2015. The Time Counter program is an progressbar that starts from the beginning of the current year (01.01) and ends with the end of the current year (31.12), and the number past days/percent since the beginning of the current year. 'Time Counter' has been ported to several programming languages, including Java, JavaScript, Delphi (Pascal), and Visual Basic."
        End If
        If languagesetgs = "ua" Then
            aboutdlgtitle.Content = "Про програму " + Chr(2) + "Лiчильник часу DMITComp" + Chr(2)
            programname.Content = "Лiчильник часу DMIT Computers"
            programversion.Content = "Версiя " + Version
            copyrightlabel.Content = "© 2019-2020 DMIT Computers. Всi права захищенi."
            description.Text = "Проект Time Counter (Лічильник часу) створений на основі проекту Year Progress, що розробляється Філіпом Грасеком в 2015-му.  Програма " + Chr(2) + "Лічильник часу" + Chr(2) + " є прогрессбар, який починається з початку поточного року (01.01) і закінчується кінцем поточного року (31.12), і число минулих днів/відсотків з початку поточного року. " + Chr(2) + "Лічильник часу" + Chr(2) + "портовано на декількох мовах програмування, включаючи Java, JavaScript, Delphi (Pascal) та Visual Basic."
        End If
        If languagesetgs = "de" Then
            aboutprgfrm.aboutdlgtitle.Content = "Über das Programm " + Chr(2) + "DMITComp Zeitzähler" + Chr(2)
            aboutprgfrm.programname.Content = "DMIT Computers Zeitzähler"
            aboutprgfrm.programversion.Content = "Ausführung " + Version
            aboutprgfrm.copyrightlabel.Content = "© 2019-2020 DMIT Computers. Alle Rechte vorbehalten."
            description.Text = "Die Beschreibung ist derzeit in drei Sprachen verfügbar."
        End If
        Dim darkthsetgs As String = dmitpctckey.GetValue("DarkTheme").ToString()

    End Sub

    Private Sub description_TextChanged(sender As Object, e As TextChangedEventArgs) Handles description.TextChanged
    End Sub

    Private Sub aboutdlgtitle_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles aboutdlgtitle.MouseLeftButtonDown
        timer1.Stop()
        Me.DragMove()
        timer1.Start()
    End Sub
End Class
