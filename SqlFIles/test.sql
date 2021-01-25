select insert_user('Bohdan','Zinchenko');
select insert_notes('a0eebc99-9c0b-4ef8-bb6d-6bb9bd380a11','BohndaHeader','ThisIsBohdanBody',1);
select insert_user('Yri','Komar');
select insert_user('Yarosh','Oleg');
select insert_notes('a0eebc99-9c0b-4ef8-bb6d-6bb9bd380a12','YriHeader','ThisIsYriBody',2);
select insert_notes('a0eebc99-9c0b-4ef8-bb6d-6bb9bd380a13','YriHeader2','ThisIsYriBody2',2);
select insert_notes('a0eebc99-9c0b-4ef8-bb6d-6bb9bd380a14','YriHeader3','ThisIsYriBody3',2);
select select_note('a0eebc99-9c0b-4ef8-bb6d-6bb9bd380a13');
select update_mark('a0eebc99-9c0b-4ef8-bb6d-6bb9bd380a13');
select select_all_users_notes();
select update_mark('a0eebc99-9c0b-4ef8-bb6d-6bb9bd380a12');
select select_user_notes(2);
select select_all_users_notes();
select select_user_notes(1);
select select_note('a0eebc99-9c0b-4ef8-bb6d-6bb9bd380a14');

