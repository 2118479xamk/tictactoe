namespace WinFormsApp1 {
	public partial class Form1:Form {
		Button[] but;
		int[,] board;
		int TURN=1;//0=O, 1=X
		int WINNER=-1;
		private void initboard(){
			but=new Button[9];
			but[0]=button1;
			but[1]=button2;
			but[2]=button3;
			but[3]=button4;
			but[4]=button5;
			but[5]=button6;
			but[6]=button7;
			but[7]=button8;
			but[8]=button9;
			board=new int[3,3];
			for(int i=0;i<3;i++){
				for(int j=0;j<3;j++){
					board[i,j]=-1;
				}
			}
			update_form();
		}
		private void setboard(int x,int y){
			if(WINNER!=-1){ return;}//winner not yet found
			if(x<0){ return;}
			if(x>2){ return;}
			if(y<0){ return;}
			if(y>2){ return;}
			if(board[x,y]!=-1){ return;}//spot empty
			board[x,y]=TURN;
			TURN=(TURN+1)%2;
			WINNER=checklines();
			update_form();
		}

		private void update_form(){
		if(TURN==0){
			label1.Text="O turn to play";
		}else{
			label1.Text="X turn to play";
		}
		if(WINNER!=-1){
			if(WINNER==0){
				label1.Text="O WINS";
			}else{
				label1.Text="X WINS";
			}
		}
		string a;
			for(int i=0;i<3;i++){
				for(int j=0;j<3;j++){
					a="";
					if(board[i,j]==0){a="O"; }
					if(board[i,j]==1){a="X"; }
					but[i%3+j*3].Text=a;
				}
			}
		}
		private int checklines(){//returns -1 if no winner, 0 if O wins, 1 if X wins
		int a=-1;
			for(int i=0;i<3;i++){
				if(board[0,i]==-1){continue; }
				if(board[0,i]==board[1,i] && board[0,i]==board[2,i]){
					return board[0,i];
				}
			}
			for(int i=0;i<3;i++){
				if(board[i,0]==-1){continue; }
				if(board[i,0]==board[i,1] && board[i,0]==board[i,2]){
					return board[i,0];
				}
			}
			if(board[0,0]==board[1,1] && board[0,0]==board[2,2]){
				return board[0,0];
			}
			if(board[0,2]==board[1,1] && board[0,2]==board[2,0]){
				return board[0,2];
			}
			return -1;
		}
		public Form1() {
		InitializeComponent();
		}

		private void Form1_Load(object sender,EventArgs e) {
			initboard();
		}
		private void button1_Click(object sender,EventArgs e) {
			setboard(0,0);
		}

		private void button2_Click(object sender,EventArgs e) {
			setboard(1,0);
		}

		private void button3_Click(object sender,EventArgs e) {
			setboard(2,0);
		}

		private void button4_Click(object sender,EventArgs e) {
			setboard(0,1);
		}

		private void button5_Click(object sender,EventArgs e) {
			setboard(1,1);
		}

		private void button6_Click(object sender,EventArgs e) {
			setboard(2,1);
		}

		private void button7_Click(object sender,EventArgs e) {
			setboard(0,2);
		}

		private void button8_Click(object sender,EventArgs e) {
			setboard(1,2);
		}

		private void button9_Click(object sender,EventArgs e) {
			setboard(2,2);
		}
	}
}