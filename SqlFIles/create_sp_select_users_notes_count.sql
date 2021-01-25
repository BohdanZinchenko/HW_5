Create or replace function select_all_users_notes () returns table (id int , name varchar , last_name varchar, count int )
language sql
As $$
    select u.id ,u.first_name , u.last_name , count(Case When is_deleted =false then 1 end) from users u left join notes n on u.id = n.user_id
    group by 1
    $$;