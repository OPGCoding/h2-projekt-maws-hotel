### Backlog
[ ] welcome page / landingpage
[ ] create user
[ ] login
[ ] booking page
[ ] profile

### database backlog
[ ] database opsætning
[ ] user
[ ] room
[ ] booking
[ ] reciept

--------------------------------------------

### SQL





#### user
```
int id
string name
string email
string password


date birthday

string address
string phone_number

bool administrator

```

#### room
```
int id
float price
int digital_key
int type
string photos
```

#### booking
```
int id

int date_start
int date_end
foreign key (user_id) references user(id)
foreign key (room_id) references room(id)

 ```


#### receipt
```
int id
foreign key (booking_id) references booking(id)
float amount
string paymentMethod
string paymentStatus
```


