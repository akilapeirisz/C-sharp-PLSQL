CREATE OR REPLACE TYPE BODY library_db_apeilk_address_type AS

	MEMBER PROCEDURE add_address(num     IN VARCHAR2,
															 street  IN VARCHAR2,
															 city    IN VARCHAR2,
															 country IN VARCHAR2) IS
	BEGIN
		INSERT INTO library_db_apeilk_address_tab
		VALUES
			(library_db_apeilk_add_seq.nextval, num, street, city, country);
	END add_address;

/*
   MEMBER FUNCTION get_address (address_id   IN NUMBER) RETURN VARCHAR2
   IS
   BEGIN
     RETURN 
   
   MEMBER PROCEDURE display_address (SELF IN OUT NOCOPY library_db_apeilk_address_type)
   IS
   BEGIN
      INSERT INTO library_db_apeilk_address_tab VALUES (library_db_apeilk_add_seq.nextval, num, street, city, country);
   END add_address;
   */
END;
