Page and Component Types
Comments
DLL
Global.asax

TryIt Comment System - Testing Instructions

Setup
Instructions:
1. Extract then Load the solution into VS 2022
2. Click run "WebDownloadAPI.sln" to fully load the solution
3. Build the Solution and click the run button

4. Load webpage
5. Navigate to the Comment Service

Testing Adding Comments
1. Fill in the username, page ID, and a comment
For example, username: Armaani, Page ID: 1, and Comment: "test test comment"
2. Click "Add Comment"
3. The comment should appear in the grid below with a success message

Testing Delete Comment Function
1. Locate the comment you want to delete from the grid
2. Click the "Delete" button next to the respective comment
3. Confirm deletion in the popup dialog box
4. The comment should disappear form the grid

Notes
- All comments are grouped by Page ID
- You can only see comments for the current PageID you have entered
- Comments persist b/w sessions until deleted

TryIt Password Hashing System - Testing Instructions
1. Enter any text in the "Text to Hash" box
2. Click Generate Hash
3. See SHA265 hash result

*This is to serve as a visual example to how to application will handle passwords in the final version

