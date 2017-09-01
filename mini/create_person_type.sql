CREATE OR REPLACE TYPE library_db_apeilk_person_type AS OBJECT
(
	id_     NUMBER,
	name_   VARCHAR2(100),
	address library_db_apeilk_address_type,
	email   VARCHAR2(100),
	MEMBER PROCEDURE add_person(num     IN VARCHAR2,
															street  IN VARCHAR2,
															city    IN VARCHAR2,
															country IN VARCHAR2)
)
NOT FINAL;
