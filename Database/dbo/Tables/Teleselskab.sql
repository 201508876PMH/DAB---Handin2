--
-- Create Table    : 'Teleselskab'   
-- teleselskabID   :  
-- regning         :  
--
CREATE TABLE Teleselskab (
    teleselskabID  INT NOT NULL,
    regning        INT NOT NULL,
CONSTRAINT pk_Teleselskab PRIMARY KEY CLUSTERED (teleselskabID))