CREATE or replace FUNCTION insert_user ( name Character varying(128) , lastName CHARACTER varying (128))  returns void
    AS $$
    insert into users(first_name, last_name) VALUES (name, lastName);
    $$
LANGUAGE sql