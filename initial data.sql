--- subjects 
insert into Subjects values ('fb3aed75-98ed-4b31-8a25-706a9d84f0c0', 'Mathematics', 'Sebastian Stan')
insert into Subjects values ('8a8d9a6e-55b5-4c88-add3-4f3dd8f1441b', 'Anatomy', 'Chris Pine')
insert into Subjects values ('c0a54e39-075f-4db9-b239-8753a049d31f', 'English', 'Ironman')
insert into Subjects values ('4c1a114a-5dd0-456f-8823-1bb93c5a33f0', 'Arts', 'Alicia Keys')

--- grades 
insert into Grades values ('57069046-28e4-4de3-b61f-2be19830eb8b', 10, GETDATE())
insert into Grades values ('1479ddb1-5e8b-49a0-814e-9d7a960c4d27', 8, GETDATE())
insert into Grades values ('6705061f-4e23-4f84-b5c1-bd4ae7b629c3', 9, GETDATE())

insert into Grades values ('05a5c3d1-61d6-470f-b665-9fa9811b6374', 9.5, GETDATE())


--- subject grades
insert into SubjectGrades values ('e06b8853-fe4b-41e2-a675-2baf9027429e', '6022c911-c800-4457-94f1-66cd952b5fdd', 'fb3aed75-98ed-4b31-8a25-706a9d84f0c0', '57069046-28e4-4de3-b61f-2be19830eb8b')
insert into SubjectGrades values ('b9a8e599-8eda-4561-87ad-c7370e97af22', '6022c911-c800-4457-94f1-66cd952b5fdd', '8a8d9a6e-55b5-4c88-add3-4f3dd8f1441b', '1479ddb1-5e8b-49a0-814e-9d7a960c4d27')
insert into SubjectGrades values ('a4c83b31-cde6-427c-b145-15de46c6e68c', '6022c911-c800-4457-94f1-66cd952b5fdd', '4c1a114a-5dd0-456f-8823-1bb93c5a33f0', '6705061f-4e23-4f84-b5c1-bd4ae7b629c3')

insert into SubjectGrades values ('da849f90-6b39-44ee-b717-f98ef5407f7f', '6022c911-c800-4457-94f1-66cd952b5fdd', '4c1a114a-5dd0-456f-8823-1bb93c5a33f0', '05a5c3d1-61d6-470f-b665-9fa9811b6374')