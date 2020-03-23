program yearprogress;



uses
  Vcl.Forms,
  YearProgressForm in 'YearProgressForm.pas' {YearProgressForm1},
  AboutProgram in 'AboutProgram.pas' {AboutProgram1},
  TimeCounterUnit in 'TimeCounterUnit.pas' {TimeCounter},
  Vcl.Themes,
  Vcl.Styles;

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  TStyleManager.TrySetStyle('Turquoise Gray');
  Application.CreateForm(TYearProgressForm1, YearProgressForm1);
  Application.CreateForm(TAboutProgram1, AboutProgram1);
  Application.CreateForm(TTimeCounter, TimeCounter);
  Application.Run;
end.
