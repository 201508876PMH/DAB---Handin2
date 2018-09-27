--
-- Create Table    : 'Email'   
-- emailID         :  
-- personID        :  (references Person.personID)
--
CREATE TABLE Email (
    emailID        INT NOT NULL,
    personID       INT NOT NULL,
CONSTRAINT pk_Email PRIMARY KEY CLUSTERED (emailID),
CONSTRAINT fk_Email FOREIGN KEY (personID)
    REFERENCES Person (personID)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)