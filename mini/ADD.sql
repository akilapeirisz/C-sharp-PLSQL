ALTER TYPE library_db_apeilk_user_type ADD MEMBER PROCEDURE create_(name_   IN VARCHAR2,
                           address IN library_db_apeilk_address_type,
                           email   IN VARCHAR2,
                           uname   IN VARCHAR2(50),
                           pass    IN VARCHAR2(50));
