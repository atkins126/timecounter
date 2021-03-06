unit Mainfm;

interface

uses
  SysUtils, WinTypes, WinProcs, Messages, Classes, Graphics, Controls,
  Forms, Dialogs, ExtCtrls, Gauges, StdCtrls, Grids, Calendar, IniFiles, CalSamp, StatsFm, Settings, AboutPro;

type
  TMainForm1 = class(TForm)
    Calendar1: TCalendar;
    Label1: TLabel;
    Label2: TLabel;
    Label4: TLabel;
    Label5: TLabel;
    YearProgressBar: TGauge;
    Timer1: TTimer;
    TodayPanel: TPanel;
    TodayLabel: TLabel;
    Label3: TLabel;
    MenuButton: TButton;
    Menu: TListBox;
    Timer2: TTimer;
    Menu_Eng: TListBox;
    procedure Timer1Timer(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure MenuClick(Sender: TObject);
    procedure MenuButtonClick(Sender: TObject);
    procedure Timer2Timer(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  MainForm1: TMainForm1;

implementation

{$R *.DFM}

uses DateCmps;

procedure TMainForm1.Timer1Timer(Sender: TObject);
var OnePercent: extended;
OneDPercent: extended;
OneMPercent: extended;
OneWPercent: extended;
CurrPercent: extended;
CurrPercent2: extended;
CurrMPercent: extended;
CurrMPercent2: extended;
CurrWPercent: extended;
CurrWPercent2: extended;
CurrDPercent: extended;
CurrDPercent2: extended;
OneHour: extended;
OneDay: extended;
CurrentMinDenominator: real;
CurrentMinDenominator2: real;
CurrentMinDenominator3: real;
CurrentHDenominator2: real;
CurrentHDenominator: real;
CurrentSDenominator: real;
CurrentSDenominator2: real;
CurrentSDenominator3: real;
CurrentSDenominator4: real;
daytime: string;
minutes: string;
LDayOfWeekName: string;
Year, Month, Day1: Word;
Hour, Minute, Second, Milli: Word;
Day: Integer;
Days1: Integer;
MonthName: string;
Ini:TIniFile;
begin
try
DecodeDate(Date, Year, Month, Day1);
DecodeTime(Time, Hour, Minute, Second, Milli);
Ini:=TIniFile.Create('settings\settings.ini');
if Hour >=10 then
Minutes:=IntToStr(Hour) else Minutes:='0' + IntToStr(Hour);
if Minute >= 10 then
minutes:=IntToStr(Minute) else minutes:='0' + IntToStr(minute);
OneDPercent:=0.24;
OneWPercent:=0.07;
OnePercent:=3.65;
if(Ini.ReadString('Main','Language','')='1') then
begin
if DayOfWeek(Now) = 1 then
LDayOfWeekName:= '�����������';
if DayOfWeek(Now) = 2 then
LDayOfWeekName:= '�����������';
if DayOfWeek(Now) = 3 then
LDayOfWeekName:= '�������';
if DayOfWeek(Now) = 4 then
LDayOfWeekName:= '�����';
if DayOfWeek(Now) = 5 then
LDayOfWeekName:= '�������';
if DayOfWeek(Now) = 6 then
LDayOfWeekName:= '�������';
if DayOfWeek(Now) = 7 then
LDayOfWeekName:= '�������';
end else begin
if DayOfWeek(Now) = 1 then
LDayOfWeekName:= 'Sunday';
if DayOfWeek(Now) = 2 then
LDayOfWeekName:= 'Monday';
if DayOfWeek(Now) = 3 then
LDayOfWeekName:= 'Tuesday';
if DayOfWeek(Now) = 4 then
LDayOfWeekName:= 'Wednesday';
if DayOfWeek(Now) = 5 then
LDayOfWeekName:= 'Thursday';
if DayOfWeek(Now) = 6 then
LDayOfWeekName:= 'Friday';
if DayOfWeek(Now) = 7 then
LDayOfWeekName:= 'Saturday';
end;
if Month = 1 then
begin
Days1:= 31;
day:=0 + Day1;
end;
if Month = 2 then
begin
Days1:= 28;
day:=31 + Day1;
end;
if Month = 3 then
begin
Days1:= 31;
day:=59 + Day1;
end;
if Month = 4 then
begin
Days1:= 30;
day:=90 + Day1;
end;
if Month = 5 then
begin
Days1:= 31;
day:=120 + Day1;
end;
if Month = 6 then
begin
Days1:= 30;
day:=151 + Day1;
end;
if Month = 7 then
begin
Days1:= 31;
day:=181 + Day1;
end;
if Month = 8 then
begin
Days1:= 31;
day:=212 + Day1;
end;
if Month = 9 then
begin
Days1:= 30;
day:=243 + Day1;
end;
if Month = 10 then
begin
Days1:= 31;
day:=273 + Day1;
end;
if Month = 11 then
begin
Days1:= 30;
day:=304 + Day1;
end;
if Month = 12 then
begin
Days1:= 31;
day:=334 + Day1;
end;
OneMPercent:=Days1 / 100;
if(Ini.ReadString('Main','Language','')='2') then
begin
if Month = 1 then
MonthName:=' January ';
if Month = 2 then
MonthName:=' Febuary ';
if Month = 3 then
MonthName:=' March ';
if Month = 4 then
MonthName:=' April ';
if Month = 5 then
MonthName:=' May ';
if Month = 6 then
MonthName:=' June ';
if Month = 7 then
MonthName:=' Jule ';
if Month = 8 then
MonthName:=' August ';
if Month = 9 then
MonthName:=' September ';
if Month = 10 then
MonthName:=' October ';
if Month = 11 then
MonthName:=' November ';
if Month = 12 then
MonthName:=' December ';
Mainfm.MainForm1.Label4.Caption:='January ' + IntToStr(Year);
Mainfm.MainForm1.Label5.Caption:='December ' + IntToStr(Year);
Mainfm.MainForm1.Label1.Caption:='passed';
if MainForm1.WindowState=wsMinimized then MainForm1.Caption:='YearProgress | ' + IntToStr(Round(Day / OnePercent)) + '%'
else MainForm1.Caption:='DMIT Computers Time Counter (Win16)';
Datecmps.DateComparson.Caption:='Date comparson';
Datecmps.DateComparson.GroupBox1.Caption:='Parameters';
Datecmps.DateComparson.GroupBox2.Caption:='Result';
Datecmps.DateComparson.Label1.Caption:='Calculate:';
Datecmps.DateComparson.RadioButton1.Caption:='elapsed time from specified date';
Datecmps.DateComparson.RadioButton2.Caption:='remaining time until the specified date';
MenuButton.Caption:='Menu';
if(Ini.ReadString('Additionally','UnitTime','')='Days') then
begin
Label3.Caption:='days';
end else
begin
Label3.Caption:='%';
end;
AboutProgram.Caption:='About DMIT Computers Time Counter';
AboutProgram.Label1.Caption:='DMIT Computers Time Counter';
AboutProgram.Label2.Caption:='Program Version 1.5.0 Win16 (November 2019)';
AboutProgram.Label3.Caption:='This program is based on a '+#39+'Year Progress'+#39+
' project, created by Fillip Hracek in 2015, and han been successfully ported to the'+
' Pascal and JavaScript programming languages.';
AboutProgram.Label4.Caption:='Link to the original project is available only in the version with Win32 (x86/x64).';
SettingsForm.Label1.Caption:='INTERFACE';
SettingsForm.Label2.Caption:='Application Language';
SettingsForm.Label4.Caption:='Calendar';
SettingsForm.Label5.Caption:='Displays the monthly calendar along with today'+#39+'s date.';
SettingsForm.Label8.Caption:='ADDITIONALLY';
SettingsForm.Label6.Caption:='Show year progress in';
SettingsForm.Caption:='Settings';
TodayLabel.Caption:='Today is' + MonthName + IntToStr(Day1) + ', ' + IntToStr(Year);
StatisticsForm.Label1.Caption:='Year';
StatisticsForm.Label2.Caption:='Month';
StatisticsForm.Label3.Caption:='Week';
StatisticsForm.Label4.Caption:='Day';
StatisticsForm.CloseButton.Caption:='Close';
Datecmps.DateComparson.Label11.Caption:='years';
Datecmps.DateComparson.Label6.Caption:='days';
Datecmps.DateComparson.Label7.Caption:='hours';
Datecmps.DateComparson.Label8.Caption:='minutes';
Datecmps.DateComparson.Label9.Caption:='seconds';
Datecmps.DateComparson.Label10.Caption:='millisec.';
SettingsForm.ComboBox1.Visible:=False;
SettingsForm.ComboBox4.Visible:=True;
SettingsForm.ComboBox3.Visible:=False;
SettingsForm.ComboBox5.Visible:=True;
Datecmps.DateComparson.Label2.Caption:='Month';
Datecmps.DateComparson.Label3.Caption:='Year';
Datecmps.DateComparson.Label4.Caption:='Time';
Datecmps.DateComparson.Button1.Caption:='Calculate';
end;
if(Ini.ReadString('Main','Language','')='1') then
begin
if Month = 1 then
MonthName:=' ������ ';
if Month = 2 then
MonthName:=' ������� ';
if Month = 3 then
MonthName:=' ����� ';
if Month = 4 then
MonthName:=' ������ ';
if Month = 5 then
MonthName:=' ��� ';
if Month = 6 then
MonthName:=' ���� ';
if Month = 7 then
MonthName:=' ���� ';
if Month = 8 then
MonthName:=' ������� ';
if Month = 9 then
MonthName:=' �������� ';
if Month = 10 then
MonthName:=' ������� ';
if Month = 11 then
MonthName:=' ������ ';
if Month = 12 then
MonthName:=' ������� ';
Label4.Caption:='������ ' + IntToStr(Year);
Label5.Caption:='������� ' + IntToStr(Year);
Mainfm.MainForm1.Label1.Caption:='������';
Datecmps.DateComparson.Label11.Caption:='���';
Datecmps.DateComparson.Label6.Caption:='����';
Datecmps.DateComparson.Label7.Caption:='�����';
Datecmps.DateComparson.Label8.Caption:='�����';
Datecmps.DateComparson.Label9.Caption:='������';
Datecmps.DateComparson.Label10.Caption:='��������.';
Datecmps.DateComparson.Label1.Caption:='���������:';
if MainForm1.WindowState=wsMinimized then MainForm1.Caption:='YearProgress | ' + IntToStr(Round(Day / OnePercent)) + '%'
else MainForm1.Caption:='������� ������� DMIT Computers (Win16)';
Datecmps.DateComparson.Caption:='��������� ���';
Datecmps.DateComparson.GroupBox1.Caption:='���������';
Datecmps.DateComparson.GroupBox2.Caption:='���������';
MenuButton.Caption:='����';
if(Ini.ReadString('Additionally','UnitTime','')='Days') then
begin
Label3.Caption:='��.';
end else
begin
Label3.Caption:='%';
end;
AboutProgram.Caption:='� ��������� DMIT Computers Time Counter';
AboutProgram.Label1.Caption:='������� ������� DMIT Computers';
AboutProgram.Label2.Caption:='������ ��������� 1.5.0 Win16 (������ 2019)';
AboutProgram.Label3.Caption:='��� ��������� ������� �� ������ ������� Year Progress, ���������� Fillip Hracek � 2015 ����, ' +
'� ������� ����������� �� ������ ���������������� Pascal � JavaScript.';
AboutProgram.Label4.Caption:='������ ������������� ������� �������� ������ � ������ � Win32 (x86/x64).';
SettingsForm.Label1.Caption:='���������';
Datecmps.DateComparson.Label2.Caption:='�����';
Datecmps.DateComparson.Label3.Caption:='���';
Datecmps.DateComparson.Label4.Caption:='�����';
Datecmps.DateComparson.Button1.Caption:='���������';
SettingsForm.Label2.Caption:='���� ���������';
SettingsForm.Label4.Caption:='���������';
SettingsForm.Label5.Caption:='���������� �������� ��������� ������ � ����������� �����.';
SettingsForm.Label8.Caption:='�������������';
SettingsForm.Label6.Caption:='���������� ������� ������������� �';
SettingsForm.Caption:='���������';
Datecmps.DateComparson.RadioButton1.Caption:='��������� ����� � ��������� ����';
Datecmps.DateComparson.RadioButton2.Caption:='���������� ����� �� ��������� ����';

StatisticsForm.Label1.Caption:='���';
StatisticsForm.Label2.Caption:='�����';
StatisticsForm.Label3.Caption:='������';
StatisticsForm.Label4.Caption:='����';
StatisticsForm.CloseButton.Caption:='�������';
TodayLabel.Caption:='������� ' + IntToStr(Day1) + MonthName + IntToStr(Year) + ' ����';
SettingsForm.ComboBox1.Visible:=True;
SettingsForm.ComboBox4.Visible:=False;
SettingsForm.ComboBox3.Visible:=True;
SettingsForm.ComboBox5.Visible:=False;
end;
YearProgressBar.Progress:=Day;
StatisticsForm.YearProgressBar1.Progress:=Day;
if(Ini.ReadString('Main','Language','')='1') then
begin
StatisticsForm.Label5.Caption:=IntToStr(Round(Day / OnePercent)) + '% / ' + IntToStr(Day) + ' ��.';
StatisticsForm.Label6.Caption:=IntToStr(Round(Day1 / OneMPercent) - 1) + '% / ' + IntToStr(Day1) + ' ��.';
StatisticsForm.Label7.Caption:=IntToStr(Round(DayOfWeek(Now) / OneWPercent) - 1) + '% / ' + LDayOfWeekName;
StatisticsForm.Label8.Caption:=IntToStr(Round(Hour / OneDPercent)) + '% / ' + IntToStr(Hour) + ':' + Minutes;
end;
if(Ini.ReadString('Main','Language','')='2') then
begin
StatisticsForm.Label5.Caption:=IntToStr(Round(Day / OnePercent)) + '% / ' + IntToStr(Day) + ' days';
StatisticsForm.Label6.Caption:=IntToStr(Round(Day1 / OneMPercent) - 1) + '% / ' + IntToStr(Day1) + ' days';
StatisticsForm.Label7.Caption:=IntToStr(Round(DayOfWeek(Now) / OneWPercent) - 1) + '% / ' + LDayOfWeekName;
StatisticsForm.Label8.Caption:=IntToStr(Round(Hour / OneDPercent)) + '% / ' + IntToStr(Hour) + ':' + Minutes;
end;
StatisticsForm.MonthProgressBar.Progress:=Day1;
if(Ini.ReadString('Additionally','UnitTime','')='Days') then
begin
Label2.Caption:=IntToStr(Day);
end else
begin
Label2.Caption:=IntToStr(Round(Day / OnePercent))
end;
StatisticsForm.MonthProgressBar.MaxValue:=Days1;
StatisticsForm.MonthProgressBar.Progress:=Day1;
StatisticsForm.WeekProgressBar.MaxValue:=7;
StatisticsForm.WeekProgressBar.Progress:=DayOfWeek(Now);
StatisticsForm.DayProgressBar.Progress:=Hour;
if (Ini.ReadString('Main','ShowCalendar','')='Disabled') then
begin
 MainForm1.Calendar1.Visible:=False;
 MainForm1.Label2.Left:=116;
 MainForm1.Label1.Left:=152;
 MainForm1.Label3.Left:=256;
end;
if (Ini.ReadString('Main','ShowCalendar','')='Enabled') then
begin
 MainForm1.Calendar1.Visible:=True;
 MainForm1.Label2.Left:=220;
 MainForm1.Label1.Left:=256;
 MainForm1.Label3.Left:=368;
end;
except
SettingsForm.Close;
end;
end;

procedure TMainForm1.FormCreate(Sender: TObject);
var OnePercent: extended;
OneDPercent: extended;
OneMPercent: extended;
OneWPercent: extended;
CurrPercent: extended;
CurrPercent2: extended;
CurrMPercent: extended;
CurrMPercent2: extended;
CurrWPercent: extended;
CurrWPercent2: extended;
CurrDPercent: extended;
CurrDPercent2: extended;
OneHour: extended;
OneDay: extended;
CurrentMinDenominator: real;
CurrentMinDenominator2: real;
CurrentMinDenominator3: real;
CurrentHDenominator2: real;
CurrentHDenominator: real;
CurrentSDenominator: real;
CurrentSDenominator2: real;
CurrentSDenominator3: real;
CurrentSDenominator4: real;
daytime: string;
minutes: string;
LDayOfWeekName: string;
Year, Month, Day1: Word;
Hour, Minute, Second, Milli: Word;
Day: Integer;
Days1: Integer;
MonthName: string;
Ini:TIniFile;
begin
DecodeDate(Date, Year, Month, Day1);
DecodeTime(Time, Hour, Minute, Second, Milli);
if Hour >=10 then
Minutes:=IntToStr(Hour) else Minutes:='0' + IntToStr(Hour);
if Minute >= 10 then
minutes:=IntToStr(Minute) else minutes:='0' + IntToStr(minute);
OneDPercent:=0.24;
OneWPercent:=0.07;
OneMPercent:=Days1 / 100;
OnePercent:=3.65;
end;

procedure TMainForm1.MenuClick(Sender: TObject);
var Ini: TIniFile;
begin
Ini:=TIniFile.Create('settings\settings.ini');
if(Ini.ReadString('Main','Language','')='1') then
begin
  if Menu.ItemIndex = 0 then DateComparson.Show;
  if Menu.ItemIndex = 1 then StatisticsForm.Show;
  if Menu.ItemIndex = 2 then
  begin
  SettingsForm.Show;
  MainForm1.Enabled:=False;
  end;
  if Menu.ItemIndex = 3 then
  begin
  AboutProgram.Show;
  MainForm1.Enabled:=False;
  end;
  Menu.Visible:=False;
  end;
  if(Ini.ReadString('Main','Language','')='2') then
begin
  if Menu_Eng.ItemIndex = 0 then DateComparson.Show;
  if Menu_Eng.ItemIndex = 1 then StatisticsForm.Show;
  if Menu_Eng.ItemIndex = 2 then
  begin
  SettingsForm.Show;
  MainForm1.Enabled:=False;
  end;
  if Menu_Eng.ItemIndex = 3 then
  begin
  AboutProgram.Show;
  MainForm1.Enabled:=False;
  end;
  Menu_Eng.Visible:=False;
  end;
end;

procedure TMainForm1.MenuButtonClick(Sender: TObject);
var Ini: TIniFile;
begin
Ini:=TIniFile.Create('settings\settings.ini');
if(Ini.ReadString('Main','Language','')='1') then
begin
if Menu.Visible=False then
Menu.Visible:=True else Menu.Visible:=False;
end;
if(Ini.ReadString('Main','Language','')='2') then
begin
if Menu_Eng.Visible=False then
Menu_Eng.Visible:=True else Menu_Eng.Visible:=False;
end;
end;

procedure TMainForm1.Timer2Timer(Sender: TObject);
var Ini: TiniFile;
begin
Ini:=TIniFile.Create('settings\settings.ini');
if not (Ini.ReadString('Main','Language','')='1') and not (Ini.ReadString('Main','Language','')='2') then
Ini.WriteString('Main','Language','1');
if (Ini.ReadString('Main','Language','')='1') then SettingsForm.ComboBox2.ItemIndex:=0
else SettingsForm.ComboBox2.ItemIndex:=1;
if not (Ini.ReadString('Main','ShowCalendar','')='Enabled') and not (Ini.ReadString('Main','ShowCalendar','')='Disabled') then
Ini.WriteString('Main','ShowCalendar','Enabled');
if (Ini.ReadString('Main','ShowCalendar','')='Enabled') then SettingsForm.ComboBox1.ItemIndex:=0
else SettingsForm.ComboBox1.ItemIndex:=1;
if (Ini.ReadString('Main','ShowCalendar','')='Enabled') then SettingsForm.ComboBox4.ItemIndex:=0
else SettingsForm.ComboBox4.ItemIndex:=1;
if not (Ini.ReadString('Additionally','UnitTime','')='Percents')
and not (Ini.ReadString('Additionally','UnitTime','')='Days') then
Ini.WriteString('Additionally','UnitTime','Percents');
if (Ini.ReadString('Additionally','UnitTime','')='Percents') then SettingsForm.ComboBox3.ItemIndex:=0
else SettingsForm.ComboBox3.ItemIndex:=1;
if (Ini.ReadString('Main','ShowCalendar','')='Enabled') then SettingsForm.ComboBox5.ItemIndex:=0
else SettingsForm.ComboBox5.ItemIndex:=1;
Timer2.Enabled:=False;
end;

end.
