[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/cozBm6K3)
# BeeBuzz
**Read all document before starting**

Welcome to the BeeBuzz App

The BeeBuzz App should be a way to manage the bee hives.
Usually there is at least one user that is part of an organization.
One organization can have multiple users and the OrganizationId is mandatory and uniq id provided by the government.
One user will have multiple bee hives to manage.
A bee hive will have : location/ address, status (active/inactive), reason for deactivation(dead, sold)

To do:
1. Make the application runnable. (2%) GOOD
2. Add the Identity middleware (2%) GOOD
2. Create the entities for User, Organization, Beehive (2%) GOOD
3. Create the specific repos for the entities (2%) GOOD


4. Seed some data with an Admin user that is part of an initial <br/> 
   0000-0000-0000-0000 Organization and a Default and Admin roles available. (3%) PARTIALLY GETTING ERROR
5. Change the Registration page to add an Organization and the Default role to user (3%) DID NOT TOUCH


6. Create a repo method to get all the Users for an Organization (3%) GOOD
7. Create a repo method to get all the Beehives for an Organization (3%) GOOD


1 organization ---- many users
1 user ---- many hackathons



1 user ---- many beehives
