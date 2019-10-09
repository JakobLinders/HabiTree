// Coding Rainbow
// Daniel Shiffman
// http://patreon.com/codingtrain
// Code for: https://youtu.be/fcdNSZ9IzJM
var tree = [];
var leaves = [];
var count = 0;
var clickcount = 0; 
var cnv;

let habitPoints = parseInt(document.getElementById("points").innerText);

function centerCanvas() {
    var x = (windowWidth - width) / 2;
    var y = (windowHeight - height) / 2;
    cnv.position(x, y);
}
function setup() {
    console.log(habitPoints);
    cnv = createCanvas(400, 400);
    centerCanvas();
    //background(255, 0, 200);
    var a = createVector(width / 2, height);
    var b = createVector(width / 2, height - 100);
    var root = new Branch(a, b);
    tree[0] = root;

    for (var i = 0; i <= habitPoints; i++) {
        stuff()
    }
    draw()

}
function windowResized() {
    centerCanvas();
}
//function mousePressed() {
//    clickcount++;
//    if (clickcount == 1) {
//        stuff();
//        clickcount = 0;
//    }
//}


function stuff() {
    for (var i = tree.length - 1; i >= 0; i--) {
        if (!tree[i].finished) {
            tree.push(tree[i].branchA());
            tree.push(tree[i].branchB());
        }
        tree[i].finished = true;
    }
    count++;
    if (count === 10) {
        for (var i = 0; i < tree.length; i++) {
            if (!tree[i].finished) {
                var leaf = tree[i].end.copy();
                leaves.push(leaf);
            }
        }
    }
}

//function mousePressed() {
//    for (var i = tree.length - 1; i >= 0; i--) {
//        if (!tree[i].finished) {
//            tree.push(tree[i].branchA());
//            tree.push(tree[i].branchB());
//        }
//        tree[i].finished = true;
//    }
//    count++;
//    if (count === 6) {
//        for (var i = 0; i < tree.length; i++) {
//            if (!tree[i].finished) {
//                var leaf = tree[i].end.copy();
//                leaves.push(leaf);
//            }
//        }
//    }
//}

function draw() {
    //background(255);
    for (var i = 0; i < tree.length; i++) {
        tree[i].show();
        //tree[i].jitter();
    }
    for (var i = 0; i < leaves.length; i++) {
        fill(34, 139, 34);
        noStroke();
        ellipse(leaves[i].x, leaves[i].y, 8, 8);
        //leaves[i].y += random(0, 2);
    }
}