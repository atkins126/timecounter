import javax.microedition.midlet.*;
import javax.microedition.lcdui.*;
import java.*;

public class CanvasOne extends Canvas
{

// �������� ������ � ������ ������ �������������� (�� ������ �������� �����!!!)
    
    private int w = getWidth();
    private int h = getHeight();

	private Command cmExit;
	private Display display;

// ��������� ����� paint(), ������� � ����� ������������� ���� ������ =)

    protected void paint(Graphics g) {

// ������ ������ "Hello World!", ������� ������� ����� �������
// ����������� � ����� (w/2+1, h/3+1) (���)

		
		java.util.Date t = new java.util.Date();
		
		java.util.Calendar c = java.util.Calendar.getInstance();
		java.util.Calendar c2 = java.util.Calendar.getInstance();
		
		String monthnamerus = "";
		String weeknamerus = "";
		String minutesFormat = "";
		int dayOfYear = 0;
		int dayOfMonth = 0;
		
		if(c.get(java.util.Calendar.MONTH) == 0){
		 monthnamerus = " ���. ";
		 dayOfYear = 0;
		 dayOfMonth = 31;
		};
		if(c.get(java.util.Calendar.MONTH) == 1){
		 monthnamerus = " ���. ";
		 dayOfYear = 31;
		 dayOfMonth = 28;
		};
		if(c.get(java.util.Calendar.MONTH) == 2){
		 monthnamerus = " ���. ";
		 dayOfYear = 59;
		 dayOfMonth = 31;
		};
		if(c.get(java.util.Calendar.MONTH) == 3){
		 monthnamerus = " ���. ";
		 dayOfYear = 90;
		 dayOfMonth = 30;
		};
		if(c.get(java.util.Calendar.MONTH) == 4){
		 monthnamerus = " ��� ";
		 dayOfYear = 120;
		 dayOfMonth = 31;
		};
		if(c.get(java.util.Calendar.MONTH) == 5){
		 monthnamerus = " ���� ";
		 dayOfYear = 151;
		 dayOfMonth = 30;
		};
		if(c.get(java.util.Calendar.MONTH) == 6){
		 monthnamerus = " ���� ";
		 dayOfYear = 181;
		 dayOfMonth = 31;
		};
		if(c.get(java.util.Calendar.MONTH) == 7){
		 monthnamerus = " ���. ";
		 dayOfYear = 212;
		 dayOfMonth = 31;
		};
		if(c.get(java.util.Calendar.MONTH) == 8){
		 monthnamerus = " ���. ";
		 dayOfYear = 243;
		 dayOfMonth = 30;
		};
		if(c.get(java.util.Calendar.MONTH) == 9){
		 monthnamerus = " ���. ";
		 dayOfYear = 273;
		 dayOfMonth = 31;
		};
		if(c.get(java.util.Calendar.MONTH) == 10){
		 monthnamerus = " ���. ";
		 dayOfYear = 304;
		 dayOfMonth = 31;
		};
		if(c.get(java.util.Calendar.MONTH) == 11){
		 monthnamerus = " ���. ";
		 dayOfYear = 334;
		 dayOfMonth = 31;
		};
		
		if(c.get(java.util.Calendar.DAY_OF_WEEK) == 1){
		 weeknamerus = "���.";
		};
		if(c.get(java.util.Calendar.DAY_OF_WEEK) == 2){
		 weeknamerus = "���.";
		};
		if(c.get(java.util.Calendar.DAY_OF_WEEK) == 3){
		 weeknamerus = "���.";
		};
		if(c.get(java.util.Calendar.DAY_OF_WEEK) == 4){
		 weeknamerus = "���.";
		};
		if(c.get(java.util.Calendar.DAY_OF_WEEK) == 5){
		 weeknamerus = "���.";
		};
		if(c.get(java.util.Calendar.DAY_OF_WEEK) == 6){
		 weeknamerus = "���.";
		};
		if(c.get(java.util.Calendar.DAY_OF_WEEK) == 7){
		 weeknamerus = "���.";
		};
		
		if(c.get(java.util.Calendar.MINUTE) < 10){
			minutesFormat = "0" + c.get(java.util.Calendar.MINUTE);
		}
		if(c.get(java.util.Calendar.MINUTE) >= 10){
			minutesFormat = "" + c.get(java.util.Calendar.MINUTE);
		}		
		
		
		g.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_PLAIN, Font.SIZE_SMALL));
        g.drawString("��� | " + (((dayOfYear + c.get(java.util.Calendar.DAY_OF_MONTH)) * 100) / 365) + "% | " + (dayOfYear + c.get(java.util.Calendar.DAY_OF_MONTH)) + " ��.", w/18, h/18, Graphics.LEFT|Graphics.TOP);
		g.drawString("����� | " + ((c.get(java.util.Calendar.DAY_OF_MONTH) * 100) / dayOfMonth) + "% | " + c.get(java.util.Calendar.DAY_OF_MONTH) + " ��.", w/18, h/18+16, Graphics.LEFT|Graphics.TOP);
		g.drawString("������ | " + ((c.get(java.util.Calendar.DAY_OF_WEEK) * 100) / 7) + "% | " + weeknamerus, w/18, h/18+32, Graphics.LEFT|Graphics.TOP);
		g.drawString("���� | " + ((c.get(java.util.Calendar.HOUR_OF_DAY) * 100) / 24) + "% | " + c.get(java.util.Calendar.HOUR_OF_DAY) + ":" + minutesFormat, w/18, h/18+48, Graphics.LEFT|Graphics.TOP);
        g.setFont(Font.getFont(Font.FACE_PROPORTIONAL, Font.STYLE_BOLD, Font.SIZE_MEDIUM));
	    g.drawString(weeknamerus + ", " + (c.get(java.util.Calendar.DAY_OF_MONTH)) + monthnamerus + c.get(java.util.Calendar.YEAR) + " �.", w-2, h-5, Graphics.RIGHT|Graphics.BOTTOM);
	 

    } 
	
}