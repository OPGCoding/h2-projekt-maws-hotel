### \#\#\# Backlog

- \[ \] welcome page / landingpage  
- \[ \] create user  
- \[ \] login  
- \[ \] booking page  
- \[ \] profile


\#\#\# database backlog

- \[ \] database opsætning  
- \[ \] user  
- \[ \] room  
- \[ \] booking  
- \[ \] reciept


\--------------------------------------------

\#\#\# SQL

### 

\#\#\#\# user  
\`\`\`  
int id  
string name  
string email  
string password

date birthday

string address  
string phone\_number

bool administrator

\`\`\`

\#\#\#\# room  
\`\`\`  
int id  
float price  
int digital\_key  
int type  
string photos  
\`\`\`

\#\#\#\# booking  
\`\`\`  
int id

int date\_start  
int date\_end  
foreign key (user\_id) references user(id)  
foreign key (room\_id) references room(id)

 \`\`\`

\#\#\#\# receipt  
\`\`\`  
int id  
foreign key (booking\_id) references booking(id)  
float amount  
string paymentMethod  
string paymentStatus  
\`\`\`

