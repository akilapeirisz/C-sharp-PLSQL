CREATE OR REPLACE TYPE library_db_apeilk_address_type AS OBJECT
(
	address_id NUMBER,
	num        VARCHAR2(30),
	street     VARCHAR2(30),
	city       VARCHAR2(30),
	country    VARCHAR2(30),
	MEMBER PROCEDURE add_address(num     IN VARCHAR2,
															 street  IN VARCHAR2,
															 city    IN VARCHAR2,
															 country IN VARCHAR2)
)
/*
 ALTER TYPE library_db_apeilk_address_type
   ADD MEMBER FUNCTION get_address (address_id   IN NUMBER) RETURN VARCHAR2,
   ADD MEMBER PROCEDURE display_address (SELF IN OUT NOCOPY library_db_apeilk_address_type) CASCADE
*/
