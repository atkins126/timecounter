Imports System.Globalization
Imports System.Windows.Threading
Imports Microsoft.Win32

Class MainWindow

    Public timer1 As New DispatcherTimer()
    Public timer2 As New DispatcherTimer()

    Private i As Integer = 0
    Private Sub mainform_Loaded(sender As Object, e As RoutedEventArgs) Handles mainform.Loaded
        Timer1Start()
        Dim currentUserKey As RegistryKey = Registry.CurrentUser
        Dim dmitpctckey As RegistryKey = currentUserKey.CreateSubKey("Software\\DMITComp\\Time Counter")
        If dmitpctckey.GetValue("Language") <> "en" And dmitpctckey.GetValue("Language") <> "ru" And dmitpctckey.GetValue("Language") <> "ua" And dmitpctckey.GetValue("Language") <> "de" Then
            dmitpctckey.SetValue("Language", "ru")
        End If
        If dmitpctckey.GetValue("DarkTheme") <> "Enabled" And dmitpctckey.GetValue("DarkTheme") <> "Disabled" Then
            dmitpctckey.SetValue("DarkTheme", "Disabled")
        End If
        If dmitpctckey.GetValue("RefreshRate") = Nothing Then
            dmitpctckey.SetValue("RefreshRate", "5")
        End If
        janlabel.Content = "01." + Convert.ToString(Year(Now))
        declabel.Content = "12." + Convert.ToString(Year(Now))
    End Sub

    Private Sub Timer1Start()
        timer1.Interval = TimeSpan.FromMilliseconds(10000)
        AddHandler timer1.Tick, AddressOf Me.Timer1Tick
        timer1.Start()
    End Sub

    Private Sub Timer1Tick(sender As Object, e As EventArgs)
        Try
            Dim currentUserKey As RegistryKey = Registry.CurrentUser
            Dim dmitpctckey As RegistryKey = currentUserKey.CreateSubKey("Software\\DMITComp\\Time Counter")
            Dim languagesetgs As String = dmitpctckey.GetValue("Language").ToString()
            Dim darkthsetgs As String = dmitpctckey.GetValue("DarkTheme").ToString()
            Dim rratesetgs As String = dmitpctckey.GetValue("RefreshRate").ToString()
            Dim todaydate As Date = Today
            Dim todaytime As DateTime = Today
            Dim EngMonthName As String
            Dim RusMonthName As String
            Dim UkrMonthName As String
            Dim EngWeekDaySName As String
            Dim RusWeekDaySName As String
            Dim UkrWeekDaySName As String
            Dim MinuteWZ As String
            If todaydate.DayOfWeek = 1 Then
                EngWeekDaySName = "Mon"
                RusWeekDaySName = "Пнд"
                UkrWeekDaySName = "Пнд"
            End If
            If todaydate.DayOfWeek = 2 Then
                EngWeekDaySName = "Tue"
                RusWeekDaySName = "Втр"
                UkrWeekDaySName = "Втр"
            End If
            If todaydate.DayOfWeek = 3 Then
                EngWeekDaySName = "Wed"
                RusWeekDaySName = "Срд"
                UkrWeekDaySName = "Срд"
            End If
            If todaydate.DayOfWeek = 4 Then
                EngWeekDaySName = "Thu"
                RusWeekDaySName = "Чтв"
                UkrWeekDaySName = "Чтв"
            End If
            If todaydate.DayOfWeek = 5 Then
                EngWeekDaySName = "Fri"
                RusWeekDaySName = "Птн"
                UkrWeekDaySName = "Птн"
            End If
            If todaydate.DayOfWeek = 6 Then
                EngWeekDaySName = "Sat"
                RusWeekDaySName = "Сбт"
                UkrWeekDaySName = "Сбт"
            End If
            If todaydate.DayOfWeek = 0 Then
                EngWeekDaySName = "Sun"
                RusWeekDaySName = "Вск"
                UkrWeekDaySName = "Ндл"
            End If
            If Month(Now) = 1 Then
                RusMonthName = " ЯНВАРЯ "
                EngMonthName = "JANUARY "
                UkrMonthName = " СIЧНЯ "
            End If
            If Month(Now) = 2 Then
                RusMonthName = " ФЕВРАЛЯ "
                EngMonthName = "FEBRUARY "
                UkrMonthName = " ЛЮТОГО "
            End If
            If Month(Now) = 3 Then
                RusMonthName = " МАРТА "
                EngMonthName = "MARCH "
                UkrMonthName = " БЕРЕЗНЯ "
            End If
            If Month(Now) = 4 Then
                RusMonthName = " АПРЕЛЯ "
                EngMonthName = "APRIL "
                UkrMonthName = " КВIТНЯ "
            End If
            If Month(Now) = 5 Then
                RusMonthName = " МАЯ "
                EngMonthName = "MAY "
                UkrMonthName = " ТРАВНЯ "
            End If
            If Month(Now) = 6 Then
                RusMonthName = " ИЮНЯ "
                EngMonthName = "JUNE "
                UkrMonthName = " ЧЕРВНЯ "
            End If
            If Month(Now) = 7 Then
                RusMonthName = " ИЮЛЯ "
                EngMonthName = "JULE "
                UkrMonthName = " ЛИПНЯ "
            End If
            If Month(Now) = 8 Then
                RusMonthName = " августа "
                EngMonthName = "AUGUST "
                UkrMonthName = " СЕРПНЯ "
            End If
            If Month(Now) = 9 Then
                RusMonthName = " СЕНТЯБРЯ "
                EngMonthName = "SEPTEMBER "
                UkrMonthName = " ВЕРЕСНЯ "
            End If
            If Month(Now) = 10 Then
                RusMonthName = " ОКТЯБРЯ "
                EngMonthName = "OCTOBER "
                UkrMonthName = " ЖОВТНЯ "
            End If
            If Month(Now) = 11 Then
                RusMonthName = " НОЯБРЯ "
                EngMonthName = "NOVEMBER "
                UkrMonthName = " ЛИСТОПАДА "
            End If
            If Month(Now) = 12 Then
                RusMonthName = " ДЕКАБРЯ "
                EngMonthName = "DECEMBER "
                UkrMonthName = " ГРУДНЯ "
            End If
            If Minute(Now) < 10 Then
                MinuteWZ = "0" + Convert.ToString(Minute(Now))
            Else
                MinuteWZ = Convert.ToString(Minute(Now))
            End If
            If Hour(Now) >= 6 And Hour(Now) < 12 Then
                daycprogressbar.Maximum = 6
                daycprogressbar.Value = Hour(Now) - 6
                If languagesetgs = "ru" Then
                    dayclabel.Content = "Утро"
                End If
                If languagesetgs = "en" Then
                    dayclabel.Content = "Morning"
                End If
                If languagesetgs = "ua" Then
                    dayclabel.Content = "Ранок"
                End If
                daycprglabel.Content = Convert.ToString(Math.Round(((Hour(Now) - 6) + ((Minute(Now) + (Second(Now) / 60)) / 60)) / 0.06, 2)) + "%"
            End If
            If Hour(Now) >= 12 And Hour(Now) < 18 Then
                daycprogressbar.Maximum = 6
                daycprogressbar.Value = (Hour(Now) + (((Minute(Now) + (Second(Now) / 60)) / 60))) - 12
                If languagesetgs = "ru" Then
                    dayclabel.Content = "День"
                End If
                If languagesetgs = "en" Then
                    dayclabel.Content = "Daytime"
                End If
                If languagesetgs = "ua" Then
                    dayclabel.Content = "День"
                End If
                daycprglabel.Content = Convert.ToString(Math.Round(((Hour(Now) - 12) + ((Minute(Now) + (Second(Now) / 60)) / 60)) / 0.06, 2)) + "%"
            End If
            If Hour(Now) >= 18 And Hour(Now) < 24 Then
                daycprogressbar.Maximum = 6
                daycprogressbar.Value = Hour(Now) - 18
                If languagesetgs = "ru" Then
                    dayclabel.Content = "Вечер"
                End If
                If languagesetgs = "en" Then
                    dayclabel.Content = "Evening"
                End If
                If languagesetgs = "ua" Then
                    dayclabel.Content = "Вечiр"
                End If
                daycprglabel.Content = Convert.ToString(Math.Round(((Hour(Now) - 18) + ((Minute(Now) + (Second(Now) / 60)) / 60)) / 0.06, 2)) + "%"
            End If
            If Hour(Now) >= 0 And Hour(Now) < 6 Then
                daycprogressbar.Maximum = 6
                daycprogressbar.Value = Hour(Now)
                If languagesetgs = "ru" Then
                    dayclabel.Content = "Ночь"
                End If
                If languagesetgs = "ru" Then
                    dayclabel.Content = "Night"
                End If
                If languagesetgs = "ua" Then
                    dayclabel.Content = "Нiч"
                End If
                daycprglabel.Content = Convert.ToString(Math.Round((Hour(Now) + ((Minute(Now) + (Second(Now) / 60)) / 60)) / 0.06, 2)) + "%"
            End If
            Dim aboutprgfrm As New aboutprogram
#Disable Warning BC42104 ' Переменная используется до того, как ей было назначено значение
            Dim Version As String = "2.0.0 Beta (June 22, 2020)"
            Dim LastDayInMonth As Date
            LastDayInMonth = DateSerial(Year(Now), Month(Now) + 1, 0)
            Dim DayG As Double
            DayG = (Hour(Now) + ((Minute(Now) + (Second(Now) / 60)) / 60)) / 0.24
            yearprogressbar.Maximum = 365
            yearprogressbar.Value = todaydate.DayOfYear + ((Hour(Now) + (Minute(Now) / 60)) / 24)
            yearprogressbar2.Maximum = 365
            yearprogressbar2.Value = todaydate.DayOfYear + ((Hour(Now) + (Minute(Now) / 60)) / 24)
            monthprogressbar.Maximum = LastDayInMonth.Day
            monthprogressbar.Value = Day(Now) + ((Hour(Now) + (Minute(Now) / 60)) / 24)
            weekprogressbar.Maximum = 7
            weekprogressbar.Value = todaydate.DayOfWeek + ((Hour(Now) + (Minute(Now) / 60)) / 24)
            daygprogressbar.Maximum = 24
            daygprogressbar.Value = (Hour(Now) + ((Minute(Now) + (Second(Now) / 60)) / 60))
            Dim days As Double = Math.Round(todaydate.DayOfYear + ((Hour(Now) + (Minute(Now) / 60)) / 24)) / 3.65
            Dim months As Double = Math.Round(Day(Now) + ((Hour(Now) + (Minute(Now) / 60)) / 24)) / (LastDayInMonth.Day / 100)
            Dim daysInt As Integer = Math.Floor(days)
            Dim weekDayPerc = Math.Round(Weekday(Now) + ((Hour(Now) + (Minute(Now) / 60)) / 24), 2) / 0.07
            dayslabel.Content = Convert.ToString(daysInt)
            daygprglabel.Content = Convert.ToString(Math.Round(DayG, 2)) + "% / " + Convert.ToString(Hour(Now)) + ":" + MinuteWZ
            rrateslider.Value = Convert.ToInt32(rratesetgs)
            If languagesetgs = "ru" Then
                janlabel.Content = "01." + Convert.ToString(Year(Now))
                declabel.Content = "12." + Convert.ToString(Year(Now))
                todaylabel.Content = "СЕГОДНЯ " + Convert.ToString(Day(Now)) + RusMonthName + Convert.ToString(Year(Now))
                weekprglabel.Content = Convert.ToString(Math.Round(weekDayPerc, 2)) + "% / " + RusWeekDaySName
                daysprglabel.Content = Convert.ToString(Math.Round(days, 2)) + "% / " + Convert.ToString(todaydate.DayOfYear) + " дн."
                monthprglabel.Content = Convert.ToString(Math.Round(months, 2)) + "% / " + Convert.ToString(Day(Now)) + " дн."
                SettingsDlgTitle.Content = "Настройки"
                SaveBtn01.Content = "СОХРАНИТЬ"
                DarkThemeCb.Content = "Темная тема (эксперимент)"
                title.Content = "Счетчик времени DMITComp"
                StatsDlgTitle.Content = "Статистика"
                yeartitle.Content = "Год"
                MonthTitle.Content = "Месяц"
                WeekTitle.Content = "Неделя"
                DayGTitle.Content = "День (общий прогресс)"
                closeFrameBtn.Content = "ЗАКРЫТЬ"
                refreshrate_note_label.Content = "Настройки сохраняются не сразу."
                aboutprgfrm.aboutdlgtitle.Content = "О программе " + Chr(2) + "Счетчик времени DMITComp" + Chr(2)
                aboutprgfrm.programname.Content = "Счетчик времени DMIT Computers"
                aboutprgfrm.programversion.Content = "Версия " + Version
                aboutprgfrm.copyrightlabel.Content = "© 2019-2020 DMIT Computers. Все права защищены."
                uilng_label.Content = "Язык интерфейса (UI Language)"
                rrate_label.Content = "Частота обновления (в секундах)"
                rratevaluelabel.Content = Convert.ToString(Math.Round(rrateslider.Value)) + " с."
            End If
            If languagesetgs = "en" Then
                janlabel.Content = "01." + Convert.ToString(Year(Now))
                declabel.Content = "12." + Convert.ToString(Year(Now))
                todaylabel.Content = "TODAY IS " + EngMonthName + Convert.ToString(Day(Now)) + ", " + Convert.ToString(Year(Now))
                weekprglabel.Content = Convert.ToString(Math.Round(weekDayPerc, 2)) + "% / " + EngWeekDaySName
                daysprglabel.Content = Convert.ToString(Math.Round(days, 2)) + "% / " + Convert.ToString(todaydate.DayOfYear) + " days"
                monthprglabel.Content = Convert.ToString(Math.Round(months, 2)) + "% / " + Convert.ToString(Day(Now)) + " days"
                SettingsDlgTitle.Content = "Settings"
                SaveBtn01.Content = "SAVE"
                DarkThemeCb.Content = "Dark theme (Experimental)"
                title.Content = "DMITComp Time Counter"
                StatsDlgTitle.Content = "Statistics"
                yeartitle.Content = "Year"
                MonthTitle.Content = "Month"
                WeekTitle.Content = "Week"
                DayGTitle.Content = "Day (overall progress)"
                closeFrameBtn.Content = "CLOSE"
                refreshrate_note_label.Content = "Settings are not saved immediately."
                aboutprgfrm.aboutdlgtitle.Content = "About DMITComp Time Counter"
                aboutprgfrm.programname.Content = "DMIT Computers Time Counter"
                aboutprgfrm.programversion.Content = "Version " + Version
                aboutprgfrm.copyrightlabel.Content = "© 2019-2020 DMIT Computers. All rights reserved."
                uilng_label.Content = "Interface Language"
                rrate_label.Content = "Refresh Rate (in seconds)"
                rratevaluelabel.Content = Convert.ToString(Math.Round(rrateslider.Value)) + " s."
            End If
            If languagesetgs = "ua" Then
                janlabel.Content = "01." + Convert.ToString(Year(Now))
                declabel.Content = "12." + Convert.ToString(Year(Now))
                todaylabel.Content = "СЬОГОДНI " + Convert.ToString(Day(Now)) + UkrMonthName + Convert.ToString(Year(Now))
                weekprglabel.Content = Convert.ToString(Math.Round(weekDayPerc, 2)) + "% / " + UkrWeekDaySName
                daysprglabel.Content = Convert.ToString(Math.Round(days, 2)) + "% / " + Convert.ToString(todaydate.DayOfYear) + " дн."
                monthprglabel.Content = Convert.ToString(Math.Round(months, 2)) + "% / " + Convert.ToString(Day(Now)) + " дн."
                SettingsDlgTitle.Content = "Налаштування"
                SaveBtn01.Content = "ЗБЕРЕГТИ"
                DarkThemeCb.Content = "Темна тема (експеримент)"
                refreshrate_note_label.Content = "Налаштування зберiгаються не вiдразу."
                title.Content = "Лiчильник часу DMITComp"
                StatsDlgTitle.Content = "Статистика"
                yeartitle.Content = "Рiк"
                MonthTitle.Content = "Мiсяць"
                WeekTitle.Content = "Тиждень"
                DayGTitle.Content = "День (загальний прогрес)"
                closeFrameBtn.Content = "ЗАКРИТИ"
                aboutprgfrm.aboutdlgtitle.Content = "Про програму " + Chr(2) + "Лiчильник часу DMITComp" + Chr(2)
                aboutprgfrm.programname.Content = "Лiчильник часу DMIT Computers"
                aboutprgfrm.programversion.Content = "Версiя " + Version
                aboutprgfrm.copyrightlabel.Content = "© 2019-2020 DMIT Computers. Всi права захищенi."
                uilng_label.Content = "Мова iнтерфейсу (UI Language)"
                rrate_label.Content = "Частота оновлення (в секундах)"
                rratevaluelabel.Content = Convert.ToString(Math.Round(rrateslider.Value)) + " с."
            End If
            If darkthsetgs = "Enabled" Then
                Dim LGB As New LinearGradientBrush
                LGB.StartPoint = New Point(0.5, 0)
                LGB.EndPoint = New Point(0.5, 1)
                LGB.GradientStops.Add(New GradientStop(Color.FromArgb(255, 0, 0, 0), 0.0))
                LGB.GradientStops.Add(New GradientStop(Color.FromArgb(255, 75, 75, 75), 0.322))
                LGB.GradientStops.Add(New GradientStop(Color.FromArgb(255, 40, 40, 40), 0.566))
                LGB.GradientStops.Add(New GradientStop(Color.FromArgb(255, 40, 40, 40), 0.77))
                MainFormCard.Background = LGB
                title.Foreground = Brushes.White
                Dim LightGray As SolidColorBrush = New SolidColorBrush(Color.FromArgb(255, 200, 200, 200))
                Dim DarkGray As SolidColorBrush = New SolidColorBrush(Color.FromArgb(255, 40, 40, 40))
                Dim DarkGray2 As SolidColorBrush = New SolidColorBrush(Color.FromArgb(255, 75, 75, 75))
                Dim TransparentGray As SolidColorBrush = New SolidColorBrush(Color.FromArgb(160, 255, 255, 255))
                todaylabel.Foreground = LightGray
                MainFormGrid.Background = DarkGray
                janlabel.Foreground = Brushes.White
                declabel.Foreground = Brushes.White
                yearprogressbar.Background = DarkGray2
                yearprogressbar.BorderBrush = DarkGray2
                StatsDialog.Background = DarkGray
                statsgrid.Background = DarkGray
                StatsDialog.Foreground = Brushes.White
                StatsDlgTitle.Foreground = Brushes.White
                yeartitle.Foreground = Brushes.White
                MonthTitle.Foreground = Brushes.White
                WeekTitle.Foreground = Brushes.White
                DayGTitle.Foreground = Brushes.White
                dayclabel.Foreground = Brushes.White
                DarkThemeCb.IsChecked = True
                SettingsDialog.Background = DarkGray
                SettingsDialog.Foreground = Brushes.White
                settingsgrid.Background = DarkGray
                SettingsDlgTitle.Foreground = Brushes.White
                DarkThemeCb.Foreground = Brushes.White
                DarkThemeCb.BorderBrush = TransparentGray
                uilng_label.Foreground = Brushes.White
                rrate_label.Foreground = Brushes.White
                rratevaluelabel.Foreground = Brushes.White
                refreshrate_note_label.Foreground = TransparentGray
            End If
            If darkthsetgs = "Disabled" Then
                Dim LGB As New LinearGradientBrush
                LGB.StartPoint = New Point(0.5, 0)
                LGB.EndPoint = New Point(0.5, 1)
                LGB.GradientStops.Add(New GradientStop(Color.FromArgb(255, 255, 255, 255), 0.0))
                LGB.GradientStops.Add(New GradientStop(Color.FromArgb(255, 168, 168, 168), 0.322))
                LGB.GradientStops.Add(New GradientStop(Color.FromArgb(255, 168, 168, 168), 0.566))
                LGB.GradientStops.Add(New GradientStop(Color.FromArgb(255, 255, 255, 255), 0.77))
                MainFormCard.Background = LGB
                title.Foreground = Brushes.Black
                Dim LightGray As SolidColorBrush = New SolidColorBrush(Color.FromArgb(255, 200, 200, 200))
                Dim LightGray2 As SolidColorBrush = New SolidColorBrush(Color.FromArgb(255, 184, 184, 184))
                Dim DarkGray As SolidColorBrush = New SolidColorBrush(Color.FromArgb(160, 0, 0, 0))
                todaylabel.Foreground = DarkGray
                MainFormGrid.Background = Brushes.White
                janlabel.Foreground = Brushes.White
                declabel.Foreground = Brushes.White
                yearprogressbar.Background = LightGray2
                yearprogressbar.BorderBrush = LightGray2
                StatsDialog.Background = Brushes.White
                statsgrid.Background = Brushes.White
                StatsDialog.Foreground = Brushes.Black
                StatsDlgTitle.Foreground = Brushes.Black
                yeartitle.Foreground = Brushes.Black
                MonthTitle.Foreground = Brushes.Black
                WeekTitle.Foreground = Brushes.Black
                DayGTitle.Foreground = Brushes.Black
                dayclabel.Foreground = Brushes.Black
                DarkThemeCb.IsChecked = False
                SettingsDialog.Background = Brushes.White
                SettingsDialog.Foreground = Brushes.Black
                settingsgrid.Background = Brushes.White
                SettingsDlgTitle.Foreground = Brushes.Black
                DarkThemeCb.Foreground = Brushes.Black
                DarkThemeCb.BorderBrush = DarkGray
                uilng_label.Foreground = Brushes.Black
                rrate_label.Foreground = Brushes.Black
                rratevaluelabel.Foreground = Brushes.Black
                refreshrate_note_label.Foreground = DarkGray
            End If
            janlabel.Content = "01." + Convert.ToString(Year(Now))
            declabel.Content = "12." + Convert.ToString(Year(Now))
            timer1.Interval = TimeSpan.FromSeconds(Convert.ToInt32(Math.Round(rrateslider.Value)))
            startupscreen.Visibility = Visibility.Hidden
        Catch ex As Exception
            Dim currentUserKey As RegistryKey = Registry.CurrentUser
            Dim dmitpctckey As RegistryKey = currentUserKey.CreateSubKey("Software\\DMITComp\\Time Counter")
            dmitpctckey.SetValue("Language", "ru")
            dmitpctckey.SetValue("DarkTheme", "Disabled")
            dmitpctckey.SetValue("RefreshRate", "5")
            janlabel.Content = "01." + Convert.ToString(Year(Now))
            declabel.Content = "12." + Convert.ToString(Year(Now))
        End Try
    End Sub

    Private Sub ListBoxItem2_Selected(sender As Object, e As RoutedEventArgs) Handles about_item.Selected
        Dim aboutprgfrm As New aboutprogram
#Disable Warning BC42104 ' Переменная используется до того, как ей было назначено значение
        aboutprgfrm.Show()
#Enable Warning BC42104 ' Переменная используется до того, как ей было назначено значение
    End Sub

    Private Sub menuBtn_Click(sender As Object, e As RoutedEventArgs) Handles menuBtn.Click
        Dim currentUserKey As RegistryKey = Registry.CurrentUser
        Dim dmitpctckey As RegistryKey = currentUserKey.CreateSubKey("Software\\DMITComp\\Time Counter")
        Dim languagesetgs As String = dmitpctckey.GetValue("Language").ToString()
        If languagesetgs = "ru" Then
            If menubox.Visibility = Visibility.Hidden Then
                menubox.Visibility = Visibility.Visible
            Else
                menubox.Visibility = Visibility.Hidden
            End If
        End If
        If languagesetgs = "en" Then
            If menubox_eng.Visibility = Visibility.Hidden Then
                menubox_eng.Visibility = Visibility.Visible
            Else
                menubox_eng.Visibility = Visibility.Hidden
            End If
        End If
        If languagesetgs = "ua" Then
            If menubox_ukr.Visibility = Visibility.Hidden Then
                menubox_ukr.Visibility = Visibility.Visible
            Else
                menubox_ukr.Visibility = Visibility.Hidden
            End If
        End If
    End Sub

    Private Sub stats_item_Selected(sender As Object, e As RoutedEventArgs) Handles stats_item.Selected
        frame1.Visibility = Visibility.Visible
        StatsDialog.Visibility = Visibility.Visible
    End Sub

    Private Sub mainform_Initialized(sender As Object, e As EventArgs) Handles mainform.Initialized
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        frame1.Visibility = Visibility.Hidden
        StatsDialog.Visibility = Visibility.Hidden
    End Sub

    Private Sub stats_item1_Selected(sender As Object, e As RoutedEventArgs) Handles stats_item1.Selected
        frame1.Visibility = Visibility.Visible
        StatsDialog.Visibility = Visibility.Visible
    End Sub

    Private Sub about_item1_Selected(sender As Object, e As RoutedEventArgs) Handles about_item1.Selected
        Dim aboutprgfrm As New aboutprogram
#Disable Warning BC42104 ' Переменная используется до того, как ей было назначено значение
        aboutprgfrm.Show()
#Enable Warning BC42104 ' Переменная используется до того, как ей было назначено значение
    End Sub

    Private Sub settingsBtn_Click(sender As Object, e As RoutedEventArgs) Handles settingsBtn.Click
        frame1.Visibility = Visibility.Visible
        SettingsDialog.Visibility = Visibility.Visible
        Dim currentUserKey As RegistryKey = Registry.CurrentUser
        Dim dmitpctckey As RegistryKey = currentUserKey.CreateSubKey("Software\\DMITComp\\Time Counter")
        Dim languagesetgs As String = dmitpctckey.GetValue("Language").ToString()
        If languagesetgs = "ru" Then
            menubox.Visibility = Visibility.Hidden
        End If
        If languagesetgs = "en" Then
            menubox_eng.Visibility = Visibility.Hidden
        End If
        If languagesetgs = "ua" Then
            menubox_ukr.Visibility = Visibility.Hidden
        End If
    End Sub

    Private Sub SaveBtn01_Click(sender As Object, e As RoutedEventArgs) Handles SaveBtn01.Click
        frame1.Visibility = Visibility.Hidden
        SettingsDialog.Visibility = Visibility.Hidden
    End Sub

    Private Sub lngcombob_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles lngcombob.SelectionChanged
        Dim currentUserKey As RegistryKey = Registry.CurrentUser
        Dim dmitpctckey As RegistryKey = currentUserKey.CreateSubKey("Software\\DMITComp\\Time Counter")

        If lngcombob.SelectedIndex = 0 Then
            dmitpctckey.SetValue("Language", "ru")
        End If
        If lngcombob.SelectedIndex = 1 Then
            dmitpctckey.SetValue("Language", "en")
        End If
        If lngcombob.SelectedIndex = 2 Then
            dmitpctckey.SetValue("Language", "ua")
        End If
    End Sub

    Private Sub stats_item2_Selected(sender As Object, e As RoutedEventArgs) Handles stats_item2.Selected
        frame1.Visibility = Visibility.Visible
        StatsDialog.Visibility = Visibility.Visible
    End Sub

    Private Sub about_item2_Selected(sender As Object, e As RoutedEventArgs) Handles about_item2.Selected
        Dim aboutprgfrm As New aboutprogram
#Disable Warning BC42104 ' Переменная используется до того, как ей было назначено значение
        aboutprgfrm.Show()
#Enable Warning BC42104 ' Переменная используется до того, как ей было назначено значение
    End Sub

    Private Sub DarkThemeCb_Checked(sender As Object, e As RoutedEventArgs)

    End Sub

    Private Sub DarkThemeCb_Click(sender As Object, e As RoutedEventArgs) Handles DarkThemeCb.Click
        Dim currentUserKey As RegistryKey = Registry.CurrentUser
        Dim dmitpctckey As RegistryKey = currentUserKey.CreateSubKey("Software\\DMITComp\\Time Counter")
        If DarkThemeCb.IsChecked = True Then
            dmitpctckey.SetValue("DarkTheme", "Enabled")
        Else
            dmitpctckey.SetValue("DarkTheme", "Disabled")
        End If
    End Sub

    Private Sub MainFormCard_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles MainFormCard.MouseLeftButtonDown
        timer1.Stop()
        Me.DragMove()
        timer1.Start()
    End Sub

    Private Sub title_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles title.MouseLeftButtonDown
        timer1.Stop()
        Me.DragMove()
        timer1.Start()
    End Sub

    Private Sub todaylabel_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles todaylabel.MouseLeftButtonDown
        timer1.Stop()
        Me.DragMove()
        timer1.Start()
    End Sub

    Private Sub QuitItem_Selected(sender As Object, e As RoutedEventArgs)
        Environment.Exit(0)
    End Sub

    Private Sub rrateslider_ValueChanged(sender As Object, e As RoutedPropertyChangedEventArgs(Of Double)) Handles rrateslider.ValueChanged

    End Sub

    Private Sub rrateslider_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles rrateslider.MouseDown
        Dim currentUserKey As RegistryKey = Registry.CurrentUser
        Dim dmitpctckey As RegistryKey = currentUserKey.CreateSubKey("Software\\DMITComp\\Time Counter")
        Dim languagesetgs As String = dmitpctckey.GetValue("Language").ToString()
        If languagesetgs = "ru" Then
            rratevaluelabel.Content = Convert.ToString(Math.Round(rrateslider.Value)) + " c."
        End If
        If languagesetgs = "en" Then
            rratevaluelabel.Content = Convert.ToString(Math.Round(rrateslider.Value)) + " s."
        End If
        If languagesetgs = "ua" Then
            rratevaluelabel.Content = Convert.ToString(Math.Round(rrateslider.Value)) + " c."
        End If
        dmitpctckey.SetValue("RefreshRate", Convert.ToString(Math.Round(rrateslider.Value)))
        timer1.Interval = TimeSpan.FromSeconds(Math.Round(rrateslider.Value))
    End Sub

    Private Sub rrateslider_MouseMove(sender As Object, e As MouseEventArgs) Handles rrateslider.MouseMove
        Dim currentUserKey As RegistryKey = Registry.CurrentUser
        Dim dmitpctckey As RegistryKey = currentUserKey.CreateSubKey("Software\\DMITComp\\Time Counter")
        Dim languagesetgs As String = dmitpctckey.GetValue("Language").ToString()
        If languagesetgs = "ru" Then
            rratevaluelabel.Content = Convert.ToString(Math.Round(rrateslider.Value)) + " c."
        End If
        If languagesetgs = "en" Then
            rratevaluelabel.Content = Convert.ToString(Math.Round(rrateslider.Value)) + " s."
        End If
        If languagesetgs = "ua" Then
            rratevaluelabel.Content = Convert.ToString(Math.Round(rrateslider.Value)) + " c."
        End If
        dmitpctckey.SetValue("RefreshRate", Convert.ToString(Math.Round(rrateslider.Value)))
        timer1.Interval = TimeSpan.FromSeconds(Math.Round(rrateslider.Value))
    End Sub
End Class
